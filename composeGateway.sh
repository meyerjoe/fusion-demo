rm ./UnmanagedGateway/gateway.fgp
dotnet fusion compose -p ./UnmanagedGateway/gateway -s ./Subgraphs/Accounts
dotnet fusion compose -p ./UnmanagedGateway/gateway -s ./Subgraphs/Products
dotnet fusion compose -p ./UnmanagedGateway/gateway -s ./Subgraphs/Reviews
dotnet fusion compose -p ./UnmanagedGateway/gateway -s ./Subgraphs/Shipping
dotnet fusion compose -p ./UnmanagedGateway/gateway -s ./Subgraphs/Notifications