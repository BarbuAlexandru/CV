package ro.alexbarbu.MandelbrotSet;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

import javax.swing.JComponent;
import javax.swing.JFrame;

@SuppressWarnings("serial")
public class Mandelbrot_Set extends JComponent implements Runnable {

	public static final double SCALE_WINDOW = 1;
	public static final int WIDTH = (int)(800 * SCALE_WINDOW);
	public static final int HEIGHT =(int)(600 * SCALE_WINDOW);
	public static final int ITERATIONS = 100;
	public static final int OVER_LIMIT = 10;
	
	public  BufferedImage image;
	public  JFrame frame;
	public mouseHandler mouse;
	
	public boolean running = false;
	public double zoom = 2;
	public double x_offset = WIDTH/2;
	public double y_offset = HEIGHT/2;
	
	
	public synchronized void start() {
		running = true;
		new Thread(this).start();
	}
	
	public synchronized void stop() {
		running = false;
	}
	
	public Mandelbrot_Set(String name) {
		frame = new JFrame(name);
		image = new BufferedImage(WIDTH, HEIGHT, BufferedImage.TYPE_INT_RGB);
		
		mouse = new mouseHandler(this);
		
		frame.addMouseListener(mouse);
		frame.addMouseMotionListener(mouse);
		frame.addMouseWheelListener(mouse);
		
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setResizable(false);
		frame.getContentPane().add(this);
		frame.pack();
		frame.setLocationRelativeTo(null);
		frame.setVisible(true);	
		
		start();
	}
	
	
	public void renderMandelbrotSet() {	
		
		for(int x = 0; x<WIDTH; x++)
			for(int y=0; y<HEIGHT; y++) {
				int color = calculatePoint((double)(x - x_offset)/(zoom * 100), (double)(y - y_offset)/(zoom*100));
				
				image.setRGB(x, y, color);
			}
		
		
	}
	

	public int calculatePoint(double x, double y) {
		double cx = x;
		double cy = y;
		
		int i = 0;
		
		for(i = 0; i< ITERATIONS; i++) {
			double nx = x*x - y*y + cx;
			double ny = 2*x*y + cy;
			x = nx;
			y = ny;
			
			if(x*x +y*y > OVER_LIMIT)
				break;
		}
		
		if(i == ITERATIONS)
			return 0x00000000;
		else {
			float comp1 = (float)((x*x +y*y)/OVER_LIMIT * 255);
			float comp2 = (float)(255 - i/ITERATIONS * 255);
			float comp3 = (float)i;
			return Color.HSBtoRGB(comp3, comp3, comp3);
		}
		
	}

	@Override
	public void addNotify() {
		setMinimumSize(new Dimension(WIDTH, HEIGHT));
		setPreferredSize(new Dimension(WIDTH, HEIGHT));
		setMaximumSize(new Dimension(WIDTH, HEIGHT));
	}
	
	
	@Override
	public void paint(Graphics g) {
		g.drawImage(image, 0, 0, null);
	}
	

	public static void main(String[] args) {	
		new Mandelbrot_Set("Mandelbrot Set");
	}

	@Override
	public void run() {
		while(running) {
			System.out.println("da "+zoom);
			renderMandelbrotSet();
			frame.repaint();
			
		}
	}


	
	
	
}
