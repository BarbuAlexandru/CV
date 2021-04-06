package Homework11;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.regex.PatternSyntaxException;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class Main {

	public static void main(String args[])  
    { 
		
		//Create the UI
		JFrame frame = new JFrame("Regular Expressions");
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setSize(500,200);
		frame.setLocation(500,500);
		
		//Create the panel
		JPanel panel = new JPanel();
		JLabel labelPattern = new JLabel("Enter Pattern below");
		JLabel labelString = new JLabel("Enter String below");
		
		//Create the text fields
		JTextField fieldPattern = new JTextField(40);
		JTextField fieldString = new JTextField(40);
		JTextField fieldAnswer = new JTextField(40);
		fieldAnswer.setEditable(false);
		fieldAnswer.setText("Enter the Inputs and press Enter");
		
		//Create Button
		JButton sendButton = new JButton("Enter");
		
		//Add the components
		panel.add(labelPattern);
		panel.add(fieldPattern);
		panel.add(labelString);
		panel.add(fieldString);
		panel.add(sendButton);
		panel.add(fieldAnswer);
		frame.add(panel);
		frame.setVisible(true);
		
		//Listen to when its pressed
		sendButton.addActionListener(new ActionListener() {

			public void actionPerformed(ActionEvent e) {
				//Take the input
				String patternString = fieldPattern.getText();
				String inputString = fieldString.getText();
				Pattern pattern = null;
				
				if(!patternString.equals("")) {
					try {
						//Compile the pattern
						pattern = Pattern.compile(patternString);
					}catch(PatternSyntaxException exception) {
						//If the pattern is invalid, throw error and exit
						System.err.println(exception.getDescription());
						System.exit(1);
					}
					
					if(!inputString.equals("")) {
						//Compare the input with the pattern
						Matcher matcher = pattern.matcher(inputString);
						boolean patternMatch = matcher.matches();
						patternMatch = matcher.lookingAt();
						
						//Display if the input respects the pattern
						if(patternMatch) {
							fieldAnswer.setText("The input respects the pattern");
						}else {
							fieldAnswer.setText("The input doesn't repsect the pattern");
						}
					}
				}
			}
		});
    }
}
