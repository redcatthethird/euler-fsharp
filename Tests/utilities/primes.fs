namespace UtilitiesTest
module PrimesTest =

    open Xunit

    open Primes

    let numberOfPrimes: obj[] list =
        [
            [| 10; 4 |]
            [| 5; 3 |]
            [| 4; 2 |]
        ]

    [<Theory>]
    [<MemberData(nameof(numberOfPrimes))>]
    let ``primes should return correct values`` n np =
        Assert.Equal(np, () |> primes |> Seq.takeWhile ((>=) n) |> Seq.length)