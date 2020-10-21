# Battleship State Tracker
.NetCore console application for tracking state of battleShips in Game of Battleship


## Building
### Dependencies
The following dependencies will be required to run the application locally:

1. Install [Dotnet-sdk](https://dotnet.microsoft.com/download)  (v3.0+)

### Build & Run
1. Install dependencies
2. Clone repo locally and the run the following commands from console window in the repo root folder:
   * Change directory `cd Battleship.state.tracker`
   * Run App `dotnet run`

## Testing / Play

* `Enter` to initialize board
* Add a ships:
  * _--addShip c=coordinates[A1-J10],l=[0-10],d=direction[H,V]_
  * Example: `--addShip c=B5,l=4,d=V`
* Take Attack:
  * _--takeAttack coordinates[A1-J10]_
  * Example: `--takeAttack B6`