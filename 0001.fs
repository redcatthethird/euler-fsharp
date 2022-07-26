﻿let numbersUntil n = [1..n-1]

let divisibleBy div x = x % div = 0

let divisibleBy3Or5 x = divisibleBy 3 x || divisibleBy 5 x

let sum = numbersUntil 1000 |>
            List.filter divisibleBy3Or5 |>
            List.sum

printf "%i" sum