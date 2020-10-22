# comp120-tinkering-graphics
This is the Tinkering Graphics project.
You complete this project in C#, following the Tinkering Graphics workshop activities and the algorithms on LearningSpace.

Daisy Baker
Matthew Roberts

Contract #2 - Forest Fires

Posterization   - This is the main function used within our program and will scans the image for each pixel and sets the r and g values much lower
ColourTolerance - This is used to check if pixels on the image are still within the threshold of a certain value
ColourDistance  - Has not been fully implimented yet but we want to impliment it to create a more specfic colour detection to then colour correct the image
Luminance       - Has not been fully implimented as we want to use luminance to make the brightness higher in the final outcome

lessYellow      - This is a function which uses colour tolerance to detect the more yellow pixels on the final image. lessYellow function was make to make the code cleaner
greyscale       - This is used first to simply change the image to greyscale which dulls the orange and red hues in the image

Instructions:
(1) To run this program simply open visual studio, open the "Tinkering_Graphics" folder.
(2) Open the .sln file on the right side of the window
(3) Open the form application
(4) Click start at the top of the window to run the form application
(5) A window will pop up and simply click the main button in the bottom left to "Remove the fake fires"
(6) To view source code simply double click on the form1 window