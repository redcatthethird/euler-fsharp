namespace UtilitiesTest
module FactorsTest =

    open Xunit

    open Factors

    let primeFactorQuantitiesEmpty: obj[] list =
        [
            [| 0 |]
            [| 1 |]
        ]

    [<Theory; MemberData(nameof(primeFactorQuantitiesEmpty))>]
    let ``primeFactorQuantities should return empty`` n =
        Assert.Empty(primeFactorQuantities n)

    let primeFactorQuantitiesSingle: obj[] list =
        [
            [| 2; 2^1 |]
            [| 3; 3^1 |]
            [| 4; 2^2 |]
            [| 5; 5^1 |]
            [| 6; 3^1 |]
            [| 6; 2^1 |]
            [| 8; 2^3 |]
        ]

    [<Theory; MemberData(nameof(primeFactorQuantitiesSingle))>]
    let ``primeFactorQuantities should return correct values`` n f =
        Assert.Contains(f, primeFactorQuantities n)