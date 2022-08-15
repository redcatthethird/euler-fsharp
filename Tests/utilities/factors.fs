namespace UtilitiesTest
module FactorsTest =

    open Xunit

    open Factors

    let primeFactorQuantitiesTestData: obj[] list =
        [
            [| 0; [| |] |]
            [| 1; [| |] |]
            [| 2; [| 2^1 |] |]
            [| 3; [| 3^1 |] |]
            [| 4; [| 2^2 |] |]
            [| 5; [| 5^1 |] |]
            [| 6; [| 2^1; 3^1 |] |]
            [| 8; [| 2^3 |] |]
        ]

    [<Theory; MemberData(nameof(primeFactorQuantitiesTestData))>]
    let ``primeFactorQuantities should return correct values`` n (f: PrimeFactorQuantity array) =
        Assert.Equal(f, primeFactorQuantities n)