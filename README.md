# GrpcDemo

gRPC is a method of web communication between services, it is kind of like an Api.
It responds the requests acroos the web and give the caller back the requested information.
The differences are how  it is set up and how it transports a data place the big differences.
gRPC relies on a known configuration that is shared between the client and the server. It is a like contract.
These contracts are called protocol buffers the other big differences between gRPC and Api is that gRPC communicates
using a binary stream this is much more efficient than a web server which can use JSON or XML.
