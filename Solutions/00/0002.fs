module S0002
open Series

let solution n =
    Seq.initInfinite fib
    |> Seq.filter (fun x -> x % 2 = 0)
    |> Seq.takeWhile ((>) n)
    |> Seq.sum