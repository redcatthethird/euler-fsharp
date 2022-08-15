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
            [| 1UL; [| 1UL |] |]
            [| 2UL; [| 2UL; 1UL |] |]
            [| 3UL; [| 3UL; 10UL; 5UL; 16UL; 8UL; 4UL; 2UL; 1UL |] |]
            [| 9UL; [| 9UL; 28UL; 14UL; 7UL; 22UL; 11UL; 34UL; 17UL; 52UL; 26UL; 13UL; 40UL; 20UL; 10UL; 5UL; 16UL; 8UL; 4UL; 2UL; 1UL |] |]
            [| 13UL; [| 13UL; 40UL; 20UL; 10UL; 5UL; 16UL; 8UL; 4UL; 2UL; 1UL |] |]
        ]

    [<Theory; MemberData(nameof(collatzTestData))>]
    let ``collatzChain should return correct values`` n (res : uint64 array) =
        Assert.Equal(res, collatzChain n)

    [<Theory; MemberData(nameof(collatzTestData))>]
    let ``collatzLength should return correct values`` n (res : uint64 array) =
        Assert.Equal(res |> Array.length |> uint64, collatzLength n)