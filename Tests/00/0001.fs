module T0001

open Xunit

[<Fact>]
let ``Solution should be correct for real case`` () =
    Assert.Equal(S0001.solution 1000, 233168)

[<Fact>]
let ``Solution should be correct for trivial case`` () =
    Assert.Equal(S0001.solution 10, 23)