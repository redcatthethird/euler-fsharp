module Primes

type Prime = uint64

// http://rosettacode.org/wiki/Sieve_of_Eratosthenes#F.23

[<RequireQualifiedAccess>]
module MinHeap =
 
  type HeapEntry<'V> = struct val k:Prime val v:'V new(k,v) = {k=k;v=v} end
  [<CompilationRepresentation(CompilationRepresentationFlags.UseNullAsTrueValue)>]
  [<NoEquality; NoComparison>]
  type PQ<'V> =
         | Mt
         | Br of HeapEntry<'V> * PQ<'V> * PQ<'V>
 
  let empty = Mt
 
  let peekMin = function | Br(kv, _, _) -> Some(kv.k, kv.v)
                         | _            -> None
 
  let rec push wk wv = 
    function | Mt -> Br(HeapEntry(wk, wv), Mt, Mt)
             | Br(vkv, ll, rr) ->
                 if wk <= vkv.k then
                   Br(HeapEntry(wk, wv), push vkv.k vkv.v rr, ll)
                 else Br(vkv, push wk wv rr, ll)
 
  let private siftdown wk wv pql pqr =
    let rec sift pl pr =
      match pl with
        | Mt -> Br(HeapEntry(wk, wv), Mt, Mt)
        | Br(vkvl, pll, plr) ->
            match pr with
              | Mt -> if wk <= vkvl.k then Br(HeapEntry(wk, wv), pl, Mt)
                      else Br(vkvl, Br(HeapEntry(wk, wv), Mt, Mt), Mt)
              | Br(vkvr, prl, prr) ->
                  if wk <= vkvl.k && wk <= vkvr.k then Br(HeapEntry(wk, wv), pl, pr)
                  elif vkvl.k <= vkvr.k then Br(vkvl, sift pll plr, pr)
                  else Br(vkvr, pl, sift prl prr)
    sift pql pqr                                        
 
  let replaceMin wk wv = function | Mt -> Mt
                                  | Br(_, ll, rr) -> siftdown wk wv ll rr

type CIS<'T> = struct val v: 'T val cont: unit -> CIS<'T> new(v,cont) = {v=v;cont=cont} end
let frstprm = 2UL
let frstoddprm = 3UL
let inc = 2UL

let primes () =
  let rec nxtprm n pq q (bps: CIS<Prime>) =
    if n >= q then let bp = bps.v in let adv = bp + bp
                   let nbps = bps.cont() in let nbp = nbps.v
                   nxtprm (n + inc) (MinHeap.push (n + adv) adv pq) (nbp * nbp) nbps
    else let ck, cv = match MinHeap.peekMin pq with
                        | None -> (q, inc) // only happens until first insertion
                        | Some kv -> kv
         if n >= ck then let rec adjpq ck cv pq =
                             let npq = MinHeap.replaceMin (ck + cv) cv pq
                             match MinHeap.peekMin npq with
                               | None -> npq // never happens
                               | Some(nk, nv) -> if n >= nk then adjpq nk nv npq
                                                 else npq
                         nxtprm (n + inc) (adjpq ck cv pq) q bps
         else CIS(n, fun() -> nxtprm (n + inc) pq q bps)
  let rec oddprms() = CIS(frstoddprm, fun() ->
      nxtprm (frstoddprm + inc) MinHeap.empty (frstoddprm * frstoddprm) (oddprms()))
  Seq.unfold (fun (cis: CIS<Prime>) -> Some(cis.v, cis.cont()))
             (CIS(frstprm, fun() -> (oddprms())))

let primesUntil n = () |> primes |> Seq.takeWhile ((>=) n)