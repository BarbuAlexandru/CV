package ro.alexbarbu.MandelbrotSet;

import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.awt.event.MouseWheelEvent;
import java.awt.event.MouseWheelListener;

public class mouseHandler implements MouseListener, MouseMotionListener, MouseWheelListener {
	
	Mandelbrot_Set obj;
	
	
	public int x_init;
	public int y_init;
	public int drag = 100;
	
	public mouseHandler(Mandelbrot_Set obj) {
		this.obj = obj;
	}
	

	

	@Override
	public void mouseDragged(MouseEvent event) {
		obj.x_offset += (event.getX() - x_init) / drag;
		obj.y_offset += (event.getY() - y_init) / drag;
	}

	@Override
	public void mouseMoved(MouseEvent event) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseClicked(MouseEvent event) {
		
	}

	@Override
	public void mouseEntered(MouseEvent event) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseExited(MouseEvent event) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mousePressed(MouseEvent event) {
		x_init = event.getX();
		y_init = event.getY();
	}

	@Override
	public void mouseReleased(MouseEvent event) {
		if(event.getButton() == MouseEvent.BUTTON3) {
			obj.zoom = 2;
			obj.x_offset = obj.WIDTH/2;
			obj.y_offset = obj.HEIGHT/2;
          }
	}

	@Override
	public void mouseWheelMoved(MouseWheelEvent event) {
		obj.zoom += 0.1 * (obj.zoom / 2);
		//obj.x_offset = event.getX();
		//obj.y_offset = event.getY();
	}

}
