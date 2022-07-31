module S0006
open Func
open Series

let square = applySecond pown 2
let sumOfSquares = numbersUntil >> List.map square >> List.sum
let squareOfSum = numbersUntil >> List.sum >> square

let solution n = squareOfSum n - sumOfSquares n