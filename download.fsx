open System.Net.Http
open System.IO

let url = "https://portal.macleans.school.nz/index.php/ics/school.ics"
(* other working urls:
    "https://gist.githubusercontent.com/DeMarko/6142417/raw/1cd301a5917141524b712f92c2e955e86a1add19/sample.ics"
    "https://www.kayaposoft.com/enrico/ics/v2.0?country=gbr&fromDate=01-01-2023&toDate=31-12-2023&region=eng"
    "https://www.phpclasses.org/browse/download/1/file/63438/name/example.ics"
    *)


let getAsync (client: HttpClient) (url: string) =
    async {
        let! content = client.GetStringAsync url |> Async.AwaitTask
        let len = content.Length
        printf "%d" len

        match len with
        | len when len < 50 -> printfn " content: %s" content
        | _ -> printfn ""
    }

let client = new HttpClient()

getAsync client url
|> Async.RunSynchronously
