open System.Net
open System.IO
open System

let urlList =
    [ "https://gist.githubusercontent.com/DeMarko/6142417/raw/1cd301a5917141524b712f92c2e955e86a1add19/sample.ics"
      "https://www.kayaposoft.com/enrico/ics/v2.0?country=gbr&fromDate=01-01-2023&toDate=31-12-2023&region=eng"
      "https://www.phpclasses.org/browse/download/1/file/63438/name/example.ics"
      "https://www.kayaposoft.com/enrico/ics/v2.0?country=gbr&fromDate=01-01-2023&toDate=31-12-2023&region=eng&holidayType=public_holiday&lang=en"
      "https://portal.macleans.school.nz/index.php/ics/school.ics" ]


let fetch url =
    let req = WebRequest.Create(Uri(url))
    let resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    use reader = new StreamReader(stream)
    let ret = reader.ReadToEnd()
    printfn "%s" ret
    printfn "%d" ret.Length

// urlList |> List.map fetch
fetch urlList[4]
