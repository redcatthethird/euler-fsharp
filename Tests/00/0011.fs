namespace T00
module T0011 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct`` () =
        Assert.Equal(70600674, S0011.solution)

    let rangeTestData: obj[] list =
        [
            [| S0011.Horizontal; 0; 19; 4; false |]
            [| S0011.Dexter; 0; 0; 4; false |]
            [| S0011.Dexter; 19; 19; 4; true |]
            [| S0011.Dexter; 19; 0; 4; false |]
            [| S0011.Dexter; 0; 19; 4; false |]
            [| S0011.Sinister; 0; 0; 4; false |]
            [| S0011.Sinister; 19; 19; 4; false |]
            [| S0011.Sinister; 0; 19; 4; true |]
            [| S0011.Sinister; 19; 0; 4; false |]
        ]

    [<Theory; MemberData(nameof(rangeTestData))>]
    let ``isInRange should return correct values`` dir coords n res =
        Assert.Equal(res, S0011.isInRange dir coords n)

    let reduceTestData: obj[] list =
        [
            [| S0011.Vertical; 0; 0; 4; 1651104 |]
            [| S0011.Horizontal; 0; 3; 4; 0 |]
            [| S0011.Dexter; 3; 3; 4; 279496 |]
        ]

    [<Theory; MemberData(nameof(reduceTestData))>]
    let ``reduceRange should return correct values`` dir coords n res =
        Assert.Equal(res, S0011.reduceRange dir coords n (*))

    let offsetTestData: obj[] list =
        [
            [| S0011.Vertical; 0; 0; 1; 1; 0 |]
            [| S0011.Horizontal; 0; 3; 4; 0; 7 |]
        ]

    [<Theory; MemberData(nameof(offsetTestData))>]
    let ``offset should return correct values`` dir coords n res =
        Assert.Equal(res, S0011.offset dir coords n)