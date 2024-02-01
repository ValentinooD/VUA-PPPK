package hr.algebra.personmanager

import android.R.attr
import android.annotation.SuppressLint
import android.app.DatePickerDialog
import android.content.Intent
import android.graphics.Bitmap
import android.net.Uri
import android.os.Bundle
import android.os.Handler
import android.os.Looper
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.navigation.fragment.findNavController
import com.google.android.material.snackbar.Snackbar
import com.squareup.picasso.Picasso
import hr.algebra.personmanager.dao.PeopleDatabase
import hr.algebra.personmanager.dao.Person
import hr.algebra.personmanager.databinding.FragmentSecondBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import java.io.File
import java.io.FileOutputStream
import java.text.SimpleDateFormat
import java.time.LocalDate
import java.util.Calendar
import java.util.Date


/**
 * A simple [Fragment] subclass as the second destination in the navigation.
 */
class SecondFragment : Fragment() {

    private var _binding: FragmentSecondBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentSecondBinding.inflate(inflater, container, false)
        return binding.root
    }

    private var calendar = Calendar.getInstance();
    private val PICKFILE_RESULT_CODE = 1
    private var fileUri: Uri? = null;
    private var filePath: String? = null;

    @SuppressLint("SimpleDateFormat")
    override fun onViewCreated(view: View, bundle: Bundle?) {
        super.onViewCreated(view, bundle)

        binding.buttonSecond.setOnClickListener {
            findNavController().navigate(R.id.action_SecondFragment_to_FirstFragment)
        }

        binding.etPicturePath.setOnClickListener {
            var chooseFile = Intent(Intent.ACTION_GET_CONTENT)
            chooseFile.setType("*/*")
            chooseFile = Intent.createChooser(chooseFile, "Choose a file")
            startActivityForResult(chooseFile, PICKFILE_RESULT_CODE)
        }

        binding.etBirth.setOnClickListener {
            Toast.makeText(requireContext(), "teest", Toast.LENGTH_SHORT).show()

            val listener = DatePickerDialog.OnDateSetListener { picker, y, m, d ->
                calendar = Calendar.getInstance()
                calendar.set(Calendar.YEAR, y)
                calendar.set(Calendar.MONTH, m)
                calendar.set(Calendar.DAY_OF_MONTH, d)

                binding.etBirth.setText(SimpleDateFormat("dd/MM/yyyy").format(Date.from(calendar.toInstant())).toString())
            }

            DatePickerDialog(requireContext(), listener,
                calendar.get(Calendar.YEAR), calendar.get(Calendar.MONDAY),
                calendar.get(Calendar.DAY_OF_MONTH))
                .show()
        }

        binding.buttonSend.setOnClickListener {
            if (!isFormValid()) {
                Snackbar.make(binding.root, "Form is invalid", Snackbar.LENGTH_LONG).show()
                return@setOnClickListener
            }

            PeopleDatabase.getInstance(requireContext()).personDao().insert(Person(
                null,
                binding.etFirstname.text.toString(),
                binding.etLastname.text.toString(),
                binding.etPicturePath.text.toString(),
                LocalDate.of(calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH), calendar.get(Calendar.DAY_OF_MONTH)),
                title = binding.etTitle.text.toString()
            ));

            findNavController().navigate(R.id.action_SecondFragment_to_FirstFragment)
        }
    }

    private fun isFormValid(): Boolean {
        var ok = true

        ok = ok and !binding.etFirstname.text.isNullOrBlank()
        ok = ok and !binding.etLastname.text.isNullOrBlank()
        ok = ok and !binding.etBirth.text.isNullOrBlank()
        ok = ok and !binding.etPicturePath.text.isNullOrBlank()

        // added later
        ok = ok and !binding.etTitle.text.isNullOrBlank()

        return ok
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)

        if (requestCode == PICKFILE_RESULT_CODE) {
            if (resultCode != -1) return;

            fileUri = data?.data;
            filePath = fileUri?.path

            val scope = CoroutineScope(Dispatchers.IO)
            scope.launch {
                val dir = requireContext().applicationContext!!.getExternalFilesDir(null)
                val file = File(dir, getRandomString(8) + ".png")
                val bitmap = Picasso.get().load(fileUri).get()
                val os = FileOutputStream(file)
                bitmap.compress(Bitmap.CompressFormat.PNG, 90, os)
                os.close()

                Handler(Looper.getMainLooper()).postDelayed(
                    {
                        binding.etPicturePath.setText(file.absolutePath)
                    },
                    10L
                )
            }
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

    fun getRandomString(length: Int) : String {
        val allowedChars = ('A'..'Z') + ('a'..'z') + ('0'..'9')
        return (1..length)
            .map { allowedChars.random() }
            .joinToString("")
    }
}