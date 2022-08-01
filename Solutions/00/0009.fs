module S0009

let isPythagoreanTriple (a, b, c) = a * a + b * b = c * c
let prod3 (a, b, c) = a * b * c

let n = 1000

let solution =
    [1..n-2]
    |> List.collect (fun a -> [1..n-a-1] |> List.map (fun b -> (a, b, 1000-a-b)))
    |> List.find isPythagoreanTriple
    |> prod3