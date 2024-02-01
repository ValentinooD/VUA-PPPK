package hr.algebra.personmanager.dao.migrations

import androidx.room.migration.Migration
import androidx.sqlite.db.SupportSQLiteDatabase

class MigrationAddTitleColumn : Migration(1, 2) {
    override fun migrate(database: SupportSQLiteDatabase) {
        database.execSQL("ALTER TABLE people ADD COLUMN title TEXT")

    }
}