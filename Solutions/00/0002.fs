module S0002

let rec fib = function
    | n when n <= 0 -> 0
    | 1 -> 1
    | n -> fib(n-1) + fib(n-2)

let solution n =
    Seq.initInfinite fib
    |> Seq.filter (fun x -> x % 2 = 0)
    |> Seq.takeWhile ((>) n)
    |> Seq.sum

printf "ok"