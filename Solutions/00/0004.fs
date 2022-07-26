module S0004

let tenTo = pown 10
let numbers n = [(tenTo n)-1 .. -1 .. tenTo (n-1)]

let log10Floor = float >> log10 >> int
let log10Ceil = log10Floor >> (+) 1

let nthDigit x n = x / (tenTo (n-1)) % 10

let digits x =
    [1..log10Ceil x]
    |> List.map (nthDigit x)

let isPalindrome x = digits x = List.rev (digits x)

let solution n =
    Seq.allPairs (numbers n) (numbers n)
    |> Seq.map (fun (x, y) -> x * y)
    |> Seq.sortDescending
    |> Seq.filter isPalindrome
    |> Seq.head