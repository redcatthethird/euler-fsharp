module T0002

open Xunit

[<Fact>]
let ``Solution should be correct for real case`` () =
    Assert.Equal(S0002.solution 4000000, 4613732)

[<Fact>]
let ``Solution should be correct for trivial case`` () =
    Assert.Equal(S0002.solution 90, 44)