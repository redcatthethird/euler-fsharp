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