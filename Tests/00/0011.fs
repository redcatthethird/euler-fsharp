namespace T00
module T0011 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct`` () =
        Assert.Equal(70600674, S0011.solution)

    let rangeTestData: obj[] list =
        [
            [| Nav2DInt32.East; 0; 19; 4; false |]
            [| Nav2DInt32.NorthWest; 0; 0; 4; false |]
            [| Nav2DInt32.NorthWest; 19; 19; 4; true |]
            [| Nav2DInt32.NorthWest; 19; 0; 4; false |]
            [| Nav2DInt32.NorthWest; 0; 19; 4; false |]
            [| Nav2DInt32.SouthEast; 0; 0; 4; false |]
            [| Nav2DInt32.SouthEast; 19; 19; 4; false |]
            [| Nav2DInt32.SouthEast; 0; 19; 4; true |]
            [| Nav2DInt32.SouthEast; 19; 0; 4; false |]
        ]

    [<Theory; MemberData(nameof(rangeTestData))>]
    let ``isInRange should return correct values`` dir coords n res =
        Assert.Equal(res, S0011.isInRange dir coords n)

    let reduceTestData: obj[] list =
        [
            [| Nav2DInt32.South; 0; 0; 4; 1651104 |]
            [| Nav2DInt32.East; 0; 3; 4; 0 |]
            [| Nav2DInt32.NorthWest; 3; 3; 4; 279496 |]
        ]

    [<Theory; MemberData(nameof(reduceTestData))>]
    let ``reduceRange should return correct values`` dir coords n res =
        Assert.Equal(res, S0011.reduceRange dir coords n (*))

    let offsetTestData: obj[] list =
        [
            [| Nav2DInt32.South; 0; 0; 1; 1; 0 |]
            [| Nav2DInt32.East; 0; 3; 4; 0; 7 |]
        ]

    [<Theory; MemberData(nameof(offsetTestData))>]
    let ``offset should return correct values`` dir coords n res =
        Assert.Equal(res, S0011.offset dir coords n)