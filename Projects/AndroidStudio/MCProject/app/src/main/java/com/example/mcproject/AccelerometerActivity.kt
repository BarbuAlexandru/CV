package com.example.mcproject

import android.content.Context
import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import android.os.Bundle
import android.view.Gravity
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class AccelerometerActivity: AppCompatActivity(), SensorEventListener{

    private lateinit var sensorManager: SensorManager
    private lateinit var textBox: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.accelerometer)

        sensorManager = getSystemService(Context.SENSOR_SERVICE) as SensorManager

        sensorManager.getDefaultSensor(Sensor.TYPE_ACCELEROMETER)?.also {
            sensorManager.registerListener(this, it, SensorManager.SENSOR_DELAY_FASTEST, SensorManager.SENSOR_DELAY_FASTEST)
        }

        textBox = findViewById<TextView>(R.id.Accelerometer_TextBox)
    }

    override fun onSensorChanged(event: SensorEvent?) {
        if(event?.sensor?.type == Sensor.TYPE_ACCELEROMETER){
            val leftRight = event.values[0]
            val upDown = event.values[1]
            val forwardBackward =event.values[2]

            textBox.gravity = Gravity.CENTER_HORIZONTAL
            textBox.text = "left/right: ${leftRight.toInt()}\nup/down: ${upDown.toInt()}\nforward/backward: ${forwardBackward.toInt()}"
        }
    }

    override fun onAccuracyChanged(p0: Sensor?, p1: Int) {
        return
    }

    override fun onDestroy() {
        sensorManager.unregisterListener(this)
        super.onDestroy()
    }
}