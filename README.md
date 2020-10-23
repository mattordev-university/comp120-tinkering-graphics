# comp120-tinkering-graphics
This is the Tinkering Graphics project.
You complete this project in C#, following the Tinkering Graphics workshop activities and the algorithms on LearningSpace.

Daisy Baker
Matthew Roberts

Contract #2 - Forest Fires


Algorithms used:
Posterization   - This is the function called when the button is pressed, it uses the rest of the functions to produce the final image.
		  the main part of this function though is individually grabbing each pixel in the image using a for loop and reducing the
		  r and g values by multiple of 0.5. The b value is set to a value of 50 each time.

colourTolerance - This algorithm is used to take the pixel colour of the image and compare it to another colour, if the pixel colour is
		  within a certain threshold of the other colour the function returns true, if not then it returns false.

Greyscale       - The greyscale function is used first, before any other image editing, to turn the image greyscale which dulls the 
		  orange and red hues in the image. This is very useful for the posterization and lessYellow functions which come after
		  as the pixel rgb editing is much more affective in the blue hues. As without greyscale the image outcome is much more
		  red and pink.

lessYellow      - This function uses the colourTolerance to detect yellow pixels on the final image, as after posterization is complete
		  the image still contains some yellow hues, to fix this the lessYellow function was made to run colourTolerance to check#
		  within a for loop, each pixel, if it was within a threshold to yellow. If it is within that threshold the pixel's r and g
		  values are left the same but the b value is set to 75. Mainly the lessYellow function was made to make the code cleaner 
		  and easier to read through and understand by someone who didn't write it.


Algorithms attempted at:
ColourDistance  - Had not been fully implimented (removed for submission) but we wanted to impliment it to create a more specfic colour 
		  detection so that the colour correction for the image could be much better.

Luminance       - Had not been fully implimented (removed for submission) but we wanted to use luminance to make the brightness higher 
	   	  in the final outcome.


Other Functions:
SavePicture     - This function is used to save the image that is being used within the project. 



Instructions:
(1) To run this program simply open visual studio, open the "Tinkering_Graphics" folder.
(2) Open the .sln file on the right side of the window.
(3) Open the form application.
(4) Click start at the top of the window to run the form application.
(5) A window will pop up and simply click the main button in the bottom left to "Remove the fake fires".
(6) To view source code simply double click on the form1 window.