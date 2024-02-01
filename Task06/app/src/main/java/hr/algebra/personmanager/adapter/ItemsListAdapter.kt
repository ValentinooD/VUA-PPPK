package hr.algebra.personmanager.adapter

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.LinearLayout
import android.widget.TextView
import androidx.navigation.fragment.findNavController
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.squareup.picasso.Picasso
import hr.algebra.personmanager.R
import hr.algebra.personmanager.dao.Person
import java.io.File

class ItemsListAdapter(private val items: MutableList<Person>, private val context: Context)
    : RecyclerView.Adapter<ItemsListAdapter.ViewHolder>()
{
    inner class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        private val tvName = itemView.findViewById<TextView>(R.id.tv_name);
        private val tvBirth = itemView.findViewById<TextView>(R.id.tv_birth);
        private val ivPicture = itemView.findViewById<ImageView>(R.id.iv_picture)

        fun bind(person: Person) {

            if (person.title != null) {
                tvName.text = person.title + " " + person.firstName + " " + person.lastName
            } else {
                tvName.text = person.firstName + " " + person.lastName
            }

            tvBirth.text = person.birthDate.toString()

            Picasso.get().load(File(person.picturePath)).into(ivPicture)

        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val itemView = LayoutInflater.from(parent.context).inflate(R.layout.item, parent, false)
        return ViewHolder((itemView))
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        holder.bind(items[position])
    }

    override fun getItemCount(): Int {
        return items.size
    }
}