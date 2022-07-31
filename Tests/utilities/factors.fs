namespace UtilitiesTest
module FactorsTest =

    open Xunit

    open Factors

    let primeFactorQuantitiesEmpty: obj[] list =
        [
            [| 0 |]
            [| 1 |]
        ]

    [<Theory>]
    [<MemberData(nameof(primeFactorQuantitiesEmpty))>]
    let ``primeFactorQuantities should return empty`` n =
        Assert.Empty(primeFactorQuantities n)

    let primeFactorQuantitiesSingle: obj[] list =
        [
            [| 5; { Factor = 5; Quantity = 1 } |]
            [| 8; { Factor = 2; Quantity = 3 } |]
        ]

    [<Theory>]
    [<MemberData(nameof(primeFactorQuantitiesSingle))>]
    let ``primeFactorQuantities should return correct values`` n fs =
        Assert.Contains(fs, primeFactorQuantities n)