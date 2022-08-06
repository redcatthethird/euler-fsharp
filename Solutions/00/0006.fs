module S0006
open Series

let square x = x * x
let sumOfSquares = numbersUntil >> List.map square >> List.sum
let squareOfSum = numbersUntil >> List.sum >> square

let solution n = squareOfSum n - sumOfSquares n