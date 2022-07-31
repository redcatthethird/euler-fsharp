#if INTERACTIVE

#r "C:/Users/JohnPant/Desktop/Repos/euler-fsharp/Solutions/bin/Debug/net6.0/Solutions.dll";
fsi.AddPrinter (fun (f:Factors.PrimeFactorQuantity) ->
    if f.Quantity = 1 then sprintf "%i" f.Factor
    else sprintf "%i^%i" f.Factor f.Quantity
)

#endif