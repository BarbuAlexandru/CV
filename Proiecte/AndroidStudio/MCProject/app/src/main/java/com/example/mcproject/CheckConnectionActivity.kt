package com.example.mcproject

import android.content.Context
import android.content.Intent
import android.net.ConnectivityManager
import android.os.Bundle
import android.provider.Settings
import android.view.Gravity
import android.view.View
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.checkconnection.*

class CheckConnectionActivity : AppCompatActivity() {

    private lateinit var textBox: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.checkconnection)

        textBox = findViewById<TextView>(R.id.checkConnection_TextBox)

        checkConnection()

        btn_tryAgain.setOnClickListener {
            finish();
            startActivity(intent);
        }

        btn_gotoWifiSettings.setOnClickListener {
            startActivity(Intent(Settings.ACTION_SETTINGS))
        }
    }

    private fun checkConnection(){
        var manager = applicationContext.getSystemService(Context.CONNECTIVITY_SERVICE) as ConnectivityManager

        val networkInfo = manager.activeNetworkInfo
        textBox.gravity = Gravity.CENTER_HORIZONTAL

        if(networkInfo!=null){
            btn_gotoWifiSettings.visibility = View.INVISIBLE
            btn_gotoWifiSettings.isClickable = false
            textBox.textSize = 30f
            if(networkInfo.type == ConnectivityManager.TYPE_WIFI){
                textBox.text = "Wifi Connected"
                Toast.makeText(this,"Wifi Connected",Toast.LENGTH_SHORT).show();
            }else if(networkInfo.type == ConnectivityManager.TYPE_MOBILE){
                textBox.text = "Mobile Data Connected"
                Toast.makeText(this,"Mobile Data Connected",Toast.LENGTH_SHORT).show();
            }
        }else{
            btn_gotoWifiSettings.visibility = View.VISIBLE
            btn_gotoWifiSettings.isClickable = true
            textBox.textSize = 20f
            textBox.text = "No Connection"+"\n"+"Please Connect to the Internet"
            Toast.makeText(this,"No Connection",Toast.LENGTH_SHORT).show();
        }
    }


}