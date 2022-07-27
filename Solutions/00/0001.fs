module S0001
open Utilities.Factors

let divisibleBy3Or5 x = divisibleBy 3 x || divisibleBy 5 x

let solution =
    numbersUntil >>
    List.filter divisibleBy3Or5 >>
    List.sum