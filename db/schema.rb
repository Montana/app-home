# encoding: UTF-8
# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# Note that this schema.rb definition is the authoritative source for your
# database schema. If you need to create the application database on another
# system, you should be using db:schema:load, not running all the migrations
# from scratch. The latter is a flawed and unsustainable approach (the more migrations
# you'll amass, the slower it'll run and the greater likelihood for issues).
#
# It's strongly recommended to check this file into your version control system.

ActiveRecord::Schema.define(:version => 20130709200114) do

  create_table "blog_posts", :force => true do |t|
    t.string   "title"
    t.string   "title_safe"
    t.integer  "author_id"
    t.text     "body"
    t.string   "summary"
    t.boolean  "is_published"
    t.string   "tags"
    t.datetime "created_at",   :null => false
    t.datetime "updated_at",   :null => false
  end

  create_table "h4_api_authentication_vaults", :force => true do |t|
    t.text     "wlid_access_token"
    t.text     "wlid_authentication_token"
    t.datetime "wlid_expire"
    t.text     "spartan_token"
    t.datetime "created_at",                :null => false
    t.datetime "updated_at",                :null => false
  end

  create_table "h4_player_challenges", :force => true do |t|
    t.text     "data",       :limit => 2147483647
    t.string   "gamertag"
    t.datetime "created_at",                       :null => false
    t.datetime "updated_at",                       :null => false
  end

  create_table "h4_player_commendations", :force => true do |t|
    t.string   "gamertag"
    t.datetime "created_at", :null => false
    t.datetime "updated_at", :null => false
  end

  create_table "h4_player_matches", :force => true do |t|
    t.string   "gamertag"
    t.string   "game_id"
    t.datetime "created_at", :null => false
    t.datetime "updated_at", :null => false
  end

  create_table "h4_player_mode_details", :force => true do |t|
    t.string   "gamertag"
    t.text     "campaign_data",    :limit => 2147483647
    t.text     "spartan_ops_data", :limit => 2147483647
    t.text     "war_games_data",   :limit => 2147483647
    t.text     "custom_data",      :limit => 2147483647
    t.datetime "created_at",                             :null => false
    t.datetime "updated_at",                             :null => false
  end

  create_table "h4_player_recent_matches", :force => true do |t|
    t.string   "gamertag"
    t.datetime "created_at",  :null => false
    t.datetime "updated_at",  :null => false
    t.integer  "start_index"
    t.integer  "count"
    t.integer  "mode_id"
    t.integer  "chapter_id"
  end

  create_table "h4_player_servicerecords", :force => true do |t|
    t.string   "gamertag"
    t.datetime "created_at", :null => false
    t.datetime "updated_at", :null => false
  end

  create_table "h4_services_lists", :force => true do |t|
    t.string   "list_type"
    t.string   "name"
    t.text     "url"
    t.datetime "created_at", :null => false
    t.datetime "updated_at", :null => false
  end

  create_table "users", :force => true do |t|
    t.string   "username"
    t.string   "email"
    t.string   "gamertag"
    t.string   "password_crypted"
    t.string   "name"
    t.boolean  "is_admin"
    t.datetime "created_at",       :null => false
    t.datetime "updated_at",       :null => false
  end

end