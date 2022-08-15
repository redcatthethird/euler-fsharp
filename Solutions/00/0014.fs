module S0014
open Series

let inline solution n = 
    n
    |> numbersUntil
    |> List.maxBy collatzLength