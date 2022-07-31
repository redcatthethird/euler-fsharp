module S0001
open Factors
open Func
open Series

let divisibleBy3Or5 x = divisibleBy 3 x || divisibleBy 5 x

let solution =
    applySecond (-) 1 >>
    numbersUntil >>
    List.filter divisibleBy3Or5 >>
    List.sum