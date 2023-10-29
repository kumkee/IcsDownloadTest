open System.Net.Http
open System.IO

let urlList =
    [ "https://gist.githubusercontent.com/DeMarko/6142417/raw/1cd301a5917141524b712f92c2e955e86a1add19/sample.ics"
      "https://www.kayaposoft.com/enrico/ics/v2.0?country=gbr&fromDate=01-01-2023&toDate=31-12-2023&region=eng"
      "https://www.phpclasses.org/browse/download/1/file/63438/name/example.ics"
      "https://www.kayaposoft.com/enrico/ics/v2.0?country=gbr&fromDate=01-01-2023&toDate=31-12-2023&region=eng&holidayType=public_holiday&lang=en"
      "https://portal.macleans.school.nz/index.php/ics/school.ics" ]


let getAsync (client: HttpClient) (url: string) =
    async {
        let! resp = client.GetAsync url |> Async.AwaitTask
        resp.EnsureSuccessStatusCode() |> ignore
        let! ret = resp.Content.ReadAsStringAsync() |> Async.AwaitTask
        let len = ret.Length
        printfn "%d" len
        (*
        match len with
            | len when len < 50 -> printfn "%s" ret
            | _ -> ignore len
        *)
    }

// urlList |> List.map fetch
let client = new HttpClient()
// getAsync client urlList[4] |> Async.RunSynchronously

urlList
|> List.map (getAsync client)
|> Async.Parallel
|> Async.RunSynchronously
