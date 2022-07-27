module S0005
open Utilities.Factors

let dividesByAllUpTo n x =
    n
    |> numbersUntil
    |> List.forall (fun div -> divisibleBy div x)

let solution n = Seq.initInfinite id |> Seq.skip 2 |> Seq.find (dividesByAllUpTo n)