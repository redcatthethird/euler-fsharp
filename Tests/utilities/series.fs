namespace UtilitiesTest
module SeriesTest =

    open Xunit

    open Series

    let triangleTestData: obj[] list =
        [
            [| 1; 1 |]
            [| 2; 3 |]
            [| 3; 6 |]
            [| 4; 10 |]
            [| 5; 15 |]
            [| 6; 21 |]
            [| 7; 28 |]
        ]

    [<Theory; MemberData(nameof(triangleTestData))>]
    let ``triangle should return correct values`` n (res : int) =
        Assert.Equal(res, triangle n)

    let collatzTestData: obj[] list =
        [
            [| 1; [| 1 |] |]
            [| 2; [| 2; 1 |] |]
            [| 3; [| 3; 10; 5; 16; 8; 4; 2; 1 |] |]
            [| 13; [| 13; 40; 20; 10; 5; 16; 8; 4; 2; 1 |] |]
        ]

    [<Theory; MemberData(nameof(collatzTestData))>]
    let ``collatzChain should return correct values`` n (res : int array) =
        Assert.Equal(res, collatzChain n)

    [<Theory; MemberData(nameof(collatzTestData))>]
    let ``collatzLength should return correct values`` n (res : int array) =
        Assert.Equal(res |> Array.length |> uint64, collatzLength n)