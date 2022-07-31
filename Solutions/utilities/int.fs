module Integral

module NumericLiteralG =
    let inline FromZero () = LanguagePrimitives.GenericZero
    let inline FromOne () = LanguagePrimitives.GenericOne
    let inline FromInt32 n = Seq.init n (fun x -> LanguagePrimitives.GenericOne) |> Seq.sum

let inline isqrt num =
    if num > 0G then
        let inline reduce n = (num / n + n) / 2G
        let rec impl n = function
            | n' when n' <= n -> n'
            | _               -> impl (reduce n) n
        let n = num / 2G + 1G
        impl (reduce n) n
    elif num = 0G then num
    else invalidArg "num" "negative numbers are not supported"