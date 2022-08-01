module Primes

// https://stackoverflow.com/questions/4629734/the-sieve-of-eratosthenes-in-f

#nowarn "40"
type cndstate = class val c:uint32 val wi:byte val md12:byte new(cnd,cndwi,mod12) = { c=cnd;wi=cndwi;md12=mod12 } end
type prmsCIS = class val p:uint32 val cont:unit->prmsCIS new(prm,nxtprmf) = { p=prm;cont=nxtprmf } end
type stateCIS<'b> = class val v:uint32 val a:'b val cont:unit->stateCIS<'b> new(curr,aux,cont)= { v=curr;a=aux;cont=cont } end
type allstateCIS<'b> = class val ss:stateCIS<'b> val cont:unit->allstateCIS<'b> new(sbstrm,cont) = { ss=sbstrm;cont=cont } end

let primes() =
  let WHLPTRN = [| 2uy;4uy;2uy;4uy;6uy;2uy;6uy;4uy;2uy;4uy;6uy;6uy;2uy;6uy;4uy;2uy;6uy;4uy;6uy;8uy;4uy;2uy;4uy;2uy;
                   4uy;8uy;6uy;4uy;6uy;2uy;4uy;6uy;2uy;6uy;6uy;4uy;2uy;4uy;6uy;2uy;6uy;4uy;2uy;4uy;2uy;10uy;2uy;10uy |]
  let rec prmsqrs v sqr = stateCIS(v,sqr,fun() -> let n=v+sqr+sqr in let n=if n<v then 0xFFFFFFFFu else n in prmsqrs n sqr)
  let rec allsqrs (prms:prmsCIS) = let s = prms.p*prms.p in allstateCIS(prmsqrs s s,fun() -> allsqrs (prms.cont()))
  let rec qdrtc v y = stateCIS(v,y,fun() -> let a=(y+1)<<<2 in let a=if a<=0 then (if a<0 then -a else 2) else a
                                            let vn=v+uint32 a in let vn=if vn<v then 0xFFFFFFFFu else vn in qdrtc vn (y+2))
  let rec allqdrtcsX4 x = allstateCIS(qdrtc (((x*x)<<<2)+1u) 1,fun()->allqdrtcsX4 (x+1u))
  let rec allqdrtcsX3 x = allstateCIS(qdrtc (((x*(x+1u))<<<1)-1u) (1 - int x),fun() -> allqdrtcsX3 (x+1u))
  let rec joinT3 (ass:allstateCIS<'b>) = stateCIS<'b>(ass.ss.v,ass.ss.a,fun()->
    let rec (^) (xs:stateCIS<'b>) (ys:stateCIS<'b>) = //union op for CoInductiveStreams
      match compare xs.v ys.v with
        | 1 -> stateCIS(ys.v,ys.a,fun() -> xs ^ ys.cont())
        | _ -> stateCIS(xs.v,xs.a,fun() -> xs.cont() ^ ys) //<= then keep all the values without combining
    let rec pairs (ass:allstateCIS<'b>) =
      let ys = ass.cont
      allstateCIS(stateCIS(ass.ss.v,ass.ss.a,fun()->ass.ss.cont()^ys().ss),fun()->pairs (ys().cont()))
    let ys = ass.cont() in let zs = ys.cont() in (ass.ss.cont()^(ys.ss^zs.ss))^joinT3 (pairs (zs.cont())))
  let rec mkprm (cs:cndstate) (sqrs:stateCIS<_>) (qX4:stateCIS<_>) (qX3:stateCIS<_>) tgl =
    let inline advcnd (cs:cndstate) =
      let inline whladv i = if i < 47uy then i + 1uy else 0uy
      let inline modadv m a = let md = m + a in if md >= 12uy then md - 12uy else md
      let a = WHLPTRN.[int cs.wi] in let nc = cs.c+uint32 a
      if nc<cs.c then failwith "Tried to enumerate primes past the numeric range!!!"
      else cndstate(nc,whladv cs.wi,modadv cs.md12 a)
    if cs.c>=sqrs.v then mkprm (if cs.c=sqrs.v then advcnd cs else cs) (sqrs.cont()) qX4 qX3 false //squarefree function
    elif cs.c>qX4.v then mkprm cs sqrs (qX4.cont()) qX3 false
    elif cs.c>qX3.v then mkprm cs sqrs qX4 (qX3.cont()) false
    else match cs.md12 with
            | 7uy -> if cs.c=qX3.v then mkprm cs sqrs qX4 (qX3.cont()) (if qX3.a>0 then not tgl else tgl) //only for a's are positive
                     elif tgl then prmsCIS(cs.c,fun() -> mkprm (advcnd cs) sqrs qX4 qX3 false)
                     else mkprm (advcnd cs) sqrs qX4 qX3 false
            | 11uy -> if cs.c=qX3.v then mkprm cs sqrs qX4 (qX3.cont()) (if qX3.a<0 then not tgl else tgl) //only for a's are negatve
                      elif tgl then prmsCIS(cs.c,fun() -> mkprm (advcnd cs) sqrs qX4 qX3 false)
                      else mkprm (advcnd cs) sqrs qX4 qX3 false
            | _ -> if cs.c=qX4.v then mkprm cs sqrs (qX4.cont()) qX3 (not tgl) //always must be 1uy or 5uy
                   elif tgl then prmsCIS(cs.c,fun() -> mkprm (advcnd cs) sqrs qX4 qX3 false)
                   else mkprm (advcnd cs) sqrs qX4 qX3 false
  let qX4s = joinT3 (allqdrtcsX4 1u) in let qX3s = joinT3 (allqdrtcsX3 1u)
  let rec baseprimes = prmsCIS(11u,fun() -> mkprm (cndstate(13u,1uy,1uy)) initsqrs qX4s qX3s false)
  and initsqrs = joinT3 (allsqrs baseprimes)
  let genseq ps = Seq.unfold (fun (psd:prmsCIS) -> Some(psd.p,psd.cont())) ps
  seq { yield 2u; yield 3u; yield 5u; yield 7u;
        yield! mkprm (cndstate(11u,0uy,11uy)) initsqrs qX4s qX3s false |> genseq }

let primesUntil n = () |> primes |> Seq.takeWhile ((>=) n) |> List.ofSeq