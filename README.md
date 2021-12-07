# Gambling-Emotions
A roulette app built to analyze gambling emotions, instructions below.

## STEP 1 - Downloads (1/3)

  Download this repository.

## STEP 2 - Downloads (2/3)

  Download the latest version of [LabRecorder](https://github.com/labstreaminglayer/App-LabRecorder/releases) and unzip it.

## STEP 3 - Downloads (3/3) + Fix

  Download [VideoAcq](https://bitbucket.org/neatlabs/videoacq/downloads/) and unzip it.  
In the extracted folder replace the "VideoAcq.py" file with the one in the previously downloaded "Misc" folder.

## STEP 4 - Python

  Download and install the latest version of [Python](https://www.python.org/downloads/).  
***IMPORTANT: Make sure to add it to PATH during installation.***

## STEP 5 - Dependencies

  Open Command Prompt (cmd) and install the following dependencies by typing their commands.
```
Dependency	Command
OpenCV:		pip install opencv-python
PyLSL:		pip install pylsl
PyQt5:		pip install PyQt5
PyXDF:		pip install pyxdf
Matplotlib:	pip install matplotlib --user
```
## STEP 6 - Start

  Run "Thesis.exe", "LabRecorder.exe", and "VideoAcq.py" in their respective folders by double clicking them.

## STEP 7 - VideoAcq

1. Assuming you have a camera connected to your device, the VideoAcq window should display it as row "1" with two columns, "Camera" and "Settings". If not, connect one and press the "Refresh" button (blue cyrcling arrows on the right).
2. Tick the box below "Camera" and press the gears button below "Settings".
3. On the Settings popup, press the "Reset" button, select the folder the video will be saved in, and press "OK".
4. Once back in the main window, press the "Record" button on the right to start recording and streaming the feed from your connected camera.

## STEP 8 - LabRecorder

  The LabRecorder window should display two streams in green letters in the "Record from Streams" panel (the game and VideoAcq). If not, press the "Update" button below it.  
Select both of the streams and press the "Start" button above them to start recording data from them.  
  
*NOTE: The default path the .xdf file is saved in is the "Documents" folder. That along with info which is part of the .xdf file name (participant, session, run, etc.) can be configured through the "Saving to..." panel on the right.*

## STEP 9 - Game

  Start playing the game. You can select multiple numbers on the layout by hovering between them or on the sides just as you would place a betting chip on the board (see [Chip Placement](https://en.wikipedia.org/wiki/Roulette#Inside_bets)). Due to limitations, you can only select one betting method at a time. Once you have, press the "Bet" button, confirm your bet, and watch the wheel spin. You can view your round, budget, bet, and outcome on the blackboard to the right. Once the results are in, wait 5 seconds, press the "Reset" button, and go again. Feel free to play until you zero or triple your initial budget. You can quit the application at any time by pressing the "Exit" button.

## STEP 10 - End

1. Once you exit the game, go back to the VideoAcq window and press the "Stop" button on the right to finish the recording.  
2. After you stop the video recording, go back to the LabRecorder window and press the "Stop" button above the streams to finish recording data.

## STEP 11 - Results

  Navigate to the folder the .xdf file was saved in, place the "Data.py" file from the previously downloaded "Misc" folder in there, run it by double clicking it, type the full name of the .xdf file on the prompt, including the ".xdf" part, and view all recorded data.
