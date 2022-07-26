module S0003

let root = float >> sqrt >> int64

let factors n =
    [root n + 1L .. -1L .. 2L]
    |> List.filter (fun x -> n % x = 0L)

let isPrime = factors >> List.isEmpty

let solution = factors >> List.filter isPrime >> List.head