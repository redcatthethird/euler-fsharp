module T0001

open Xunit

[<Fact>]
let ``Solution should have correct value`` () =
    Assert.True(S0001.solution = 233168)