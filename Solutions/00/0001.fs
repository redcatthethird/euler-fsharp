module S0001
open Factors
open Series

let divisibleBy3Or5 x = divisibleBy x 3 || divisibleBy x 5

let solution n =
    n - 1
    |> numbersUntil
    |> List.filter divisibleBy3Or5
    |> List.sum