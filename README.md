# Test downloading `ics` files in .Net framework

This is a single F# script showing a failed try to download `ics` files with the
Base Class Library `System.Net.Http`.

To run the script, run

```shell
dotnet fsi downlad.fsx
```

It fails to download the last `ics` in the list returning an error message
`ERR: Missing UA30`. Using Linux command `curl` will download the whole file
correctly with the error.
