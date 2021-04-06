package homework2;

import java.awt.BorderLayout;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.JButton;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class GraphApp  {

	public static void main(String[] args) {
		GraphEditor graphEditor = new GraphEditor("Graph Editor", 1000, 700);
        JPanel panel = new JPanel();
        
        JButton deselectButton = new JButton("Deselect");
        JButton deleteButton = new JButton("Delete");
        JButton saveButton = new JButton("Save");
        
        JTextField keyField = new JTextField(15);
		JTextField valueField = new JTextField(15);
		
        panel.add(deselectButton);
        panel.add(deleteButton);
        panel.add(keyField);
        panel.add(valueField);
        panel.add(saveButton);
        
        graphEditor.add(panel);
        graphEditor.setVisible(true);
		
		panel.addMouseListener(new MouseAdapter() {
        	public void mousePressed(MouseEvent event) {
        		int xSearch= event.getX()-18; //*****
        		int ySearch=event.getY()+7;
        		int xPlace= event.getX()+7;
        		int yPlace= event.getY()+32;
        		
        		if(graphEditor.IsSelected()) {
        			if(graphEditor.NodeIsSelected()) {
        				if(graphEditor.NodeFound(xSearch, ySearch)) {
        					if(graphEditor.EdgeBetween(graphEditor.selectedNode, graphEditor.GetSecondNode(xSearch, ySearch))) {
        						
        					}else {
        						graphEditor.addEdge("","", graphEditor.selectedNode, graphEditor.GetSecondNode(xSearch, ySearch));
        						graphEditor.DeselectAll();
        					}
        				}else {
        					graphEditor.MoveSelected(xPlace, yPlace);
        				}
        			}
        		}else {
        			if(graphEditor.SelectComponent(xSearch, ySearch)) {
        				
        			}else {
        				graphEditor.addNode(keyField.getText(),valueField.getText(),xPlace, yPlace);
        				keyField.setText("");
						valueField.setText("");
        			}
        		}
        	}
        });
		
		deleteButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				if(graphEditor.IsSelected()) {
					if(graphEditor.NodeIsSelected()) {
						graphEditor.DeleteSelectedNode();
					}else {
						graphEditor.DeleteSelectedEdge();
					}
				}
			}
		});
		
		deselectButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				if(graphEditor.IsSelected()) {
					graphEditor.DeselectAll();
				}
			}
		});
		
		saveButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				if(graphEditor.IsSelected()) {
					if(graphEditor.NodeIsSelected()) {
						graphEditor.EditNode(keyField.getText(), valueField.getText());
						keyField.setText("");
						valueField.setText("");
						graphEditor.DeselectAll();
					}else {
						graphEditor.EditEdge(keyField.getText(), valueField.getText());
						keyField.setText("");
						valueField.setText("");
						graphEditor.DeselectAll();
					}
				}
			}
		});
	}
}
