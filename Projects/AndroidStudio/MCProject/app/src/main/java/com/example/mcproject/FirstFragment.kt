package com.example.mcproject

import android.content.Intent
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import androidx.navigation.fragment.findNavController
import kotlinx.android.synthetic.main.fragment_first.*

/**
 * A simple [Fragment] subclass as the default destination in the navigation.
 */
class FirstFragment : Fragment() {

    override fun onCreateView(
            inflater: LayoutInflater, container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_first, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        view.findViewById<Button>(R.id.button_first).setOnClickListener {
            findNavController().navigate(R.id.action_FirstFragment_to_SecondFragment)
        }

        btn_gotoAccelerometer.setOnClickListener {
            startActivity(Intent(this.context, AccelerometerActivity::class.java))
        }

        btn_gotoTakePicture.setOnClickListener {
            startActivity(Intent(this.context, TakePictureActivity::class.java))
        }

        btn_gotoCheckConnection.setOnClickListener {
            startActivity(Intent(this.context, CheckConnectionActivity::class.java))
        }

        btn_gotoMap.setOnClickListener {
            startActivity(Intent(this.context, MapActivity::class.java))
        }
    }
}