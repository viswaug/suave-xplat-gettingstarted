// --------------------------------------------------------------------------------------
// Minimal Suave.io server!
// --------------------------------------------------------------------------------------

#r "packages/Suave/lib/net40/Suave.dll"
#r "packages/DotLiquid/lib/net451/DotLiquid.dll"
open Suave
open Suave.Web
open Suave.Filters
open Suave.Operators
let app : WebPart = choose [
                                GET >=> choose [ 
                                    path "/" >=> Successful.OK "ROOT"
                                    path "/hello" >=> Successful.OK "hello"
                                    path "/goodbye" >=> Successful.OK "good bye"
                                ]
                                POST >=> choose [
                                    path "/" >=> Successful.OK "POST ROOT"
                                    path "/hello" >=> Successful.OK "POST hello"
                                    path "/goodbye" >=> Successful.OK "POST good bye"
                                ]
                            ]

// If you prefer to run things manually in F# Interactive (over running 'build' in 
// command line), then you can use the following commands to start the server
#if TESTING
// Starts the server on http://localhost:8083
let config = { defaultConfig with homeFolder = Some __SOURCE_DIRECTORY__ }
let _, server = startWebServerAsync config app
let cts = new System.Threading.CancellationTokenSource()
Async.Start(server, cts.Token)
// Kill the server (so that you can restart it)
cts.Cancel()
#endif