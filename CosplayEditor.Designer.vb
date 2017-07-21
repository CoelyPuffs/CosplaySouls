<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CosplayEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CosplayEditor))
        Me.entityBox = New System.Windows.Forms.ComboBox()
        Me.helmetName = New System.Windows.Forms.ComboBox()
        Me.armorName = New System.Windows.Forms.ComboBox()
        Me.gauntletsName = New System.Windows.Forms.ComboBox()
        Me.leggingsName = New System.Windows.Forms.ComboBox()
        Me.leftOneName = New System.Windows.Forms.ComboBox()
        Me.rightOneName = New System.Windows.Forms.ComboBox()
        Me.leftTwoName = New System.Windows.Forms.ComboBox()
        Me.rightTwoName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.applyButton = New System.Windows.Forms.Button()
        Me.helmetLevel = New System.Windows.Forms.ComboBox()
        Me.armorLevel = New System.Windows.Forms.ComboBox()
        Me.gauntletsLevel = New System.Windows.Forms.ComboBox()
        Me.leggingsLevel = New System.Windows.Forms.ComboBox()
        Me.leftOneLevel = New System.Windows.Forms.ComboBox()
        Me.rightOneLevel = New System.Windows.Forms.ComboBox()
        Me.LeftTwoLevel = New System.Windows.Forms.ComboBox()
        Me.rightTwoLevel = New System.Windows.Forms.ComboBox()
        Me.leftOneInfusion = New System.Windows.Forms.ComboBox()
        Me.rightOneInfusion = New System.Windows.Forms.ComboBox()
        Me.leftTwoInfusion = New System.Windows.Forms.ComboBox()
        Me.rightTwoInfusion = New System.Windows.Forms.ComboBox()
        Me.exportButton = New System.Windows.Forms.Button()
        Me.importButton = New System.Windows.Forms.Button()
        Me.vitSet = New System.Windows.Forms.NumericUpDown()
        Me.atnSet = New System.Windows.Forms.NumericUpDown()
        Me.endSet = New System.Windows.Forms.NumericUpDown()
        Me.strSet = New System.Windows.Forms.NumericUpDown()
        Me.dexSet = New System.Windows.Forms.NumericUpDown()
        Me.resSet = New System.Windows.Forms.NumericUpDown()
        Me.intSet = New System.Windows.Forms.NumericUpDown()
        Me.fthSet = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.vitSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.atnSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.endSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.strSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dexSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.resSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.intSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fthSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'entityBox
        '
        Me.entityBox.FormattingEnabled = True
        Me.entityBox.Items.AddRange(New Object() {"Rat", "Small Rat", "Large Rat", "Snow Rat", "Infested Ghoul", "Stray Demon", "Demon Firesage", "Asylum Demon", "Capra Demon", "Taurus Demon", "Batwing Demon", "Mushroom Parent", "Mushroom Child", "Titanite Demon", "Crow Demon", "Iron Golem", "Demonic Foliage ", "Smough", "Channeler", "Giant Stone Knight", "Darkwraith", "Painting Guardian", "Silver Knight", "Demonic Statue", "Hollow", "Undead Merchant", "Undead Assassin", "Blowdart Sniper", "Armored Hollow", "Undead Soldier", "Balder Knight", "Berenike Knight", "Andre of Astora", "Necromancer", "Butcher", "Ghost (Male)", "Ghost (Female)", "Serpent Soldier", "Serpent Mage", "Crystal Golem", "Golden Crystal Golem", "Crossbreed Priscilla", "Anastacia of Astora", "Mimic", "Black Knight (Sword)", "Black Knight (Great Sword)", "Black Knight (Axe)", "Black Knight (Halberd)", "Undead Crystal Soldier", "Infested Barbarian (Club)", "Infested Barbarian (Boulder)", "Phalanx", "Engorged Zombie", "Giant", "Sentinel or Royal Sentinel", "Skeleton", "Giant Skeleton", "Vamos", "Bonewheel Skeleton", "Skeleton Baby", "Skeleton Beast", "Bone Tower", "Giant Mosquito", "Slime", "Egg Carrier", "Vile Maggot", "Moonlight Butterfly", "Chaos Eater", "Man-Eater Shell", "Basilisk", "Crystal Lizard", "Pinwheel", "Pisaca", "Undead Attack Dog", "Flaming Attack Dog", "Possessed Tree", "Tree Lizard", "Giant Leech", "Burrowing Rockworm", "Crag-Spider", "Frog-Ray", "Undead Dragon", "Bounding Demon of Izalith", "Hellkite Drake", "Everlasting Dragon", "Armored Tusk", "Armored Tusk (Reinforced)", "Sanctuary Guardian", "Chaos Bug", "Good Vagrant", "Evil Vagrant", "Mass of Souls", "Wisp (exploding skull)", "Asylum Transport Crow", "Drake", "Hydra", "Hydra Head", "Marvelous Chester", "Artorias", "Hawkeye Gough", "Stone Guardian", "Scarecrow", "Elizabeth", "Bloathead", "Bloathead Sorcerer", "Humanity Phantom (small)", "Humanity Phantom (medium)", "Humanity Phantom (large)", "Chained Prisoner", "Attack Dog (DLC)", "Manus, Father of the Abyss", "Black Dragon Kalameet", "Young Sif", "Centipede Demon", "Centipede Demon's Arm", "Centipede Demon's Tail", "Sif", "Gravelord Nito", "Bed of Chaos", "Parasitic Wall Hugger", "Ceaseless Discharge", "Gaping Dragon", "Ornstein", "Super Ornstein", "Quelaag", "Seath the Scaleless", "Gwynevere", "Gwyndolin", "Frampt / Kaathe", "The Fair Lady", "Bell Gargoyles", "Lightning Gargoyles", "Great Feline", "Alvina", "Alvina", "Gwyn", "Four Kings"})
        Me.entityBox.Location = New System.Drawing.Point(16, 70)
        Me.entityBox.Margin = New System.Windows.Forms.Padding(4)
        Me.entityBox.Name = "entityBox"
        Me.entityBox.Size = New System.Drawing.Size(265, 33)
        Me.entityBox.TabIndex = 0
        '
        'helmetName
        '
        Me.helmetName.DropDownWidth = 200
        Me.helmetName.FormattingEnabled = True
        Me.helmetName.Items.AddRange(New Object() {"No Change", "Bare", "Balder Helm", "Big Hat", "Black Iron Helm", "Black Knight Helm", "Black Sorcerer Hat", "Bloated Head", "Bloated Sorcerer Head", "Brass Helm", "Brigand Hood", "Catarina Helm", "Chain Helm", "Cleric Helm", "Crown of Dusk", "Crown of the Dark Sun", "Crown of the Great Lord", "Crystalline Helm", "Dark Mask", "Dingy Hood", "Dragon Head", "Eastern Helm", "Egg Head", "Elite Cleric Helm", "Elite Knight Helm", "Fang Boar Helm", "Gargoyle Helm", "Giant Helm", "Gold-Hemmed Black Hood", "Golem Helm", "Ghough's Helm", "Guardian Helm", "Havel's Helm", "Helm of Artorias", "Helm of Favor", "Helm of the Wise", "Helm of Thorns", "Hollow Soldier Helm", "Hollow Theif's Hood", "Hollow Warrior Helm", "Iron Helm", "Knight Helm", "Mage Smith Hat", "Maiden Hood", "Mask of the Child", "Mask of the Father", "Mask of the Mother", "Mask of the Sealer", "Mask of Velka", "Ornstein's Helm", "Painting Guardian Hood", "Paladin Helm", "Pharis's Hat", "Porcelain Mask", "Priest's Hat", "Royal Helm", "Sack", "Shadow Mask", "Silver Knight Helm", "Six-Eyed Helm of the Channelers", "Smough's Helm", "Snickering Top Hat", "Sorcerer Hat", "Standard Helm", "Steel Helm", "Stone Helm", "Sunlight Maggot", "Symbol of Avarice", "Tattered Cloth Hood", "Theif Mask", "Wanderer Hood", "Witch Hat", "Xanthous Crown"})
        Me.helmetName.Location = New System.Drawing.Point(245, 615)
        Me.helmetName.Margin = New System.Windows.Forms.Padding(4)
        Me.helmetName.Name = "helmetName"
        Me.helmetName.Size = New System.Drawing.Size(265, 33)
        Me.helmetName.TabIndex = 16
        '
        'armorName
        '
        Me.armorName.DropDownWidth = 200
        Me.armorName.FormattingEnabled = True
        Me.armorName.Items.AddRange(New Object() {"No Change", "Bare", "Antiquated Dress", "Armor of Artorias", "Armor of the Glorious", "Armor of the Sun", "Armor of Thorns", "Balder Armor", "Black Cleric Robe", "Black Iron Armor", "Black Knight Armor", "Black Leather Armor", "Black Sorcerer Cloak", "Brass Armor", "Brigand Armor", "Catarina Armor", "Chain Armor", "Chester's Long Coat", "Cleric Armor", "Crimson Robe", "Crystalline Armor", "Dark Armor", "Dingy Robe", "Dragon Torso", "Eastern Armor", "Elite Cleric Armor", "Elite Knight Armor", "Embraced Armor of Favor", "Giant Armor", "Gold-Hemmed Black Cloak", "Golem Armor", "Gough's Armor", "Guardian Armor", "Hard Leather Armor", "Havel's Armor", "Hollow Soldier Armor", "Hollow Theif's Leather Armor", "Hollow Warrior Armor", "Holy Robe", "Knight Armor", "Leather Armor", "Lord's Blade Robe", "Maiden Robe", "Mage Smith Coat", "Moonlight Robe", "Ornstein's Armor", "Painting Guardian Robe", "Paladin Armor", "Robe of the Channelers", "Robe of the Great Lord", "Sage Robe", "Shadow Garb", "Silver Knight Armor", "Smough's Armor", "Sorcerer Cloak", "Steel Armor", "Stone Armor", "Tattered Cloth Robe", "Wanderer Coat", "Witch Cloak", "Xanthous Overcoat"})
        Me.armorName.Location = New System.Drawing.Point(520, 615)
        Me.armorName.Margin = New System.Windows.Forms.Padding(4)
        Me.armorName.Name = "armorName"
        Me.armorName.Size = New System.Drawing.Size(265, 33)
        Me.armorName.TabIndex = 18
        '
        'gauntletsName
        '
        Me.gauntletsName.DropDownWidth = 200
        Me.gauntletsName.FormattingEnabled = True
        Me.gauntletsName.Items.AddRange(New Object() {"No Change", "Bare", "Antiquated Gloves", "Balder Gauntlets", "Black Iron Gauntlets", "Black Knight Gauntlets", "Black Leather Gloves", "Black Manchette", "Black Sorcerer Gauntlets", "Bracelet of the Great Lord", "Brass Gauntlets", "Brigand Gauntlets", "Catarina Gauntlets", "Chester`s Gloves", "Cleric Gauntlets", "Crimson Gloves", "Crystalline Gauntlets", "Dark Gauntlets", "Dingy Gloves", "Dragon Arms", "Eastern Gauntlets", "Elite Cleric Gauntlets", "Elite Knight Gauntlets", "Gauntlets of Artorias", "Gauntlets of Favor", "Gauntlets of the Channelers", "Gauntlets of the Vanquisher", "Gauntlets of Thorns", "Giant Gauntlets", "Gold-Hemmed Black Gloves", "Golem Gauntlets", "Gough`s Gauntlets", "Guardian Gauntlets", "Hard Leather Gauntlets", "Havel`s Gauntlets", "Iron Bracelet", "Knight Gauntlets", "Leather Gauntlets", "Leather Gloves", "Lord`s Blade Gloves", "Mage Smith Gauntlets", "Maiden Gloves", "Moonlight Gloves", "Ornstein`s Gauntlets", "Painting Guardian Gloves", "Paladin Gauntlets", "Shadow Gauntlets", "Silver Knight Gauntlets", "Smough`s Gauntlets", "Sorcerer Gauntlets", "Steel Gauntlets", "Stone Gauntlets", "Tattered Cloth Manchette", "Traveling Gloves", "Wanderer Manchette", "Witch Gloves", "Xanthous Gloves"})
        Me.gauntletsName.Location = New System.Drawing.Point(795, 615)
        Me.gauntletsName.Margin = New System.Windows.Forms.Padding(4)
        Me.gauntletsName.Name = "gauntletsName"
        Me.gauntletsName.Size = New System.Drawing.Size(265, 33)
        Me.gauntletsName.TabIndex = 20
        '
        'leggingsName
        '
        Me.leggingsName.DropDownWidth = 200
        Me.leggingsName.FormattingEnabled = True
        Me.leggingsName.Items.AddRange(New Object() {"No Change", "Bare", "Anklet of the Great Lord", "Antiquated Skirt", "Balder Leggings", "Black Iron Leggings", "Black Knight Leggings", "Black Leather Boots", "Black Sorcerer Boots", "Black Tights", "Blood-Stained Skirt", "Boots of the Explorer", "Brass Leggings", "Brigand Trousers", "Catarina Leggings", "Chain Leggings", "Chester`s Trousers", "Cleric Leggings", "Crimson Waistcloth", "Crystalline Leggings", "Dark Leggings", "Dragon Legs", "Eastern Leggings", "Elite Cleric Leggings", "Elite Knight Leggings", "Giant Leggings", "Gold-Hemmed Black Skirt", "Golem Leggings", "Gough`s Leggings", "Guardian Leggings", "Hard Leather Boots", "Havel`s Leggings", "Heavy Boots", "Hollow Soldier Waistcloth", "Hollow Thief`s Tights", "Hollow Warrior Waistcloth", "Holy Trousers", "Iron Leggings", "Knight Leggings", "Leather Boots", "Leggings of Artorias", "Leggings of Favor", "Leggings of Thorns", "Lord`s Blade Waistcloth", "Mage Smith Boots", "Maiden Skirt", "Moonlight Waistcloth", "Ornstein`s Leggings", "Painting Guardian Waistcloth", "Paladin Leggings", "Shadow Leggings", "Silver Knight Leggings", "Smough`s Leggings", "Sorcerer Boots", "Steel Leggings", "Stone Leggings", "Traveling Boots", "Waistcloth of the Channelers", "Wanderer Boots", "Witch Skirt", "Xanthous Waistcloth"})
        Me.leggingsName.Location = New System.Drawing.Point(1069, 615)
        Me.leggingsName.Margin = New System.Windows.Forms.Padding(4)
        Me.leggingsName.Name = "leggingsName"
        Me.leggingsName.Size = New System.Drawing.Size(265, 33)
        Me.leggingsName.TabIndex = 22
        '
        'leftOneName
        '
        Me.leftOneName.DropDownWidth = 200
        Me.leftOneName.FormattingEnabled = True
        Me.leftOneName.Items.AddRange(New Object() {"No Change", "Bare", "Caestus", "Claw", "Dark Hand", "Dragon Bone Fist", "Blacksmith Giant Hammer", "Blacksmith Hammer", "Hammer of Vamos", "Club", "Mace", "Morning Star", "Pickaxe", "Reinforced Club", "Warpick", "Demon's Great Hammer", "Dragon Tooth", "Grant", "Great Club", "Large Club", "Smough's Hammer", "Battle Axe", "Butcher Knife", "Crescent Axe", "Gargoyle Tail Axe", "Golem Axe", "Hand Axe", "Black Knight Greataxe", "Demon's Greataxe", "Dragon King Greataxe", "Greataxe", "Stone Greataxe", "Bandit's Knife", "Dagger", "Dark Silver Tracer", "Ghost Blade", "Parrying Dagger", "Priscilla's Dagger", "Estoc", "Mail Breaker", "Rapier", "Ricard's Rapier", "Velka's Rapier", "Astora's Straight Sword", "Balder Side Sword", "Barbed Straight Sword", "Broad Sword", "Broken Straight Sword", "Crystal Straight Sword", "Dark Sword", "Drake Sword", "Longsword", "Shortsword", "Silver Knight Straight Sword", "Straight Sword Hilt", "Sunlight Straight Sword", "Abyss Greatsword", "Bastard Sword", "Black Knight Sword", "Claymore", "Crystal Greatsword", "Flamberge", "Great Lord Greatsword", "Greatsword of Artorias", "Greatsword of Artorias (Cursed)", "Man Serpent Greatsword", "Moonlight Greatsword", "Obsidian Greatsword", "Stone Greatsword", "Black Knight Greatsword", "Demon Great Machete", "Dragon Greatsword", "Greatsword", "Zweihander", "Chaos Blade", "Iaito", "Uchigatana", "Washing Pole", "Falchion", "Gold Tracer", "Jagged Ghost Blade", "Painting Guardian Sword", "Quelaag's Fury Sword", "Scimitar", "Shotel", "Gravelord Sword", "Murakumo", "Server", "Channeler's Trident", "Demon's Spear", "Dragonslayer Spear", "Four-Pronged Plow", "Moonlight Butterfly Horn", "Partizan", "Pike", "Silver Knight Spear", "Spear", "Winged Spear", "Black Knight Halberd", "Gargoyle's Halberd", "Giant's Halberd", "Great Scythe", "Halberd", "Lifehunt Scythe", "Lucerne", "Scythe", "Titanite Catch Pole", "Black Bow of Pharis", "Composite Bow", "Darkmoon Bow", "Long Bow", "Short Bow", "Avelyn", "Heavy Crossbow", "Light Crossbow", "Sniper Crossbow", "Dragonslayer Greatbow", "Gough's Greatbow", "Guardian Tail", "Notched Whip", "Whip", "Beatrice's Catalyst", "Demon's Catalyst", "Izalith Catalyst", "Logan's Catalyst", "Manus Catalyst", "Oolacile Catalyst", "Oolacile Ivory Catalyst", "Sorcerer's Catalyst", "Tin Banishment Catalyst", "Tin Crystallization Catalyst", "Tin Darkmoon Catalyst", "Canvas Talisman", "Darkmoon Talisman", "Ivory Talisman", "Sunlight Talisman", "Talisman", "Thorolund Talisman", "Velka's Talisman", "Skull Lantern", "Ascended Pyromancy Flame", "Pyromancy Flame", "Buckler", "Caduceus Round Shield", "Cracked Round Shield", "Effigy Shield", "Leather Shield", "Plank Shield", "Red and White Round Shield", "Small Leather Shield", "Target Shield", "Warrior's Round Shield", "Balder Shield", "Black Knight Shield", "Bloodshield", "Caduceus Kite Shield", "Crest Shield", "Dragon Crest Shield", "East-West Shield", "Gargoyle's Shield", "Grass Crest Shield", "Heater Shield", "Hollow Soldier Shield", "Iron Round Shield", "Knight Shield", "Large Leather Shield", "Sanctus", "Silver Knight Shield", "Spider Shield", "Sunlight Shield", "Tower Kite Shield", "Wooden Shield", "Black Iron Greatshield", "Bonewheel Shield", "Cleansing Greatshield", "Eagle Shield", "Giant Shield", "Greatshield of Artorias", "Havel's Greatshield", "Stone Greatshield", "Tower Shield", "Crystal Ring Shield", "Crystal Shield", "Spiked Shield", "Pierce Shield", "Dark Hand"})
        Me.leftOneName.Location = New System.Drawing.Point(245, 401)
        Me.leftOneName.Margin = New System.Windows.Forms.Padding(4)
        Me.leftOneName.Name = "leftOneName"
        Me.leftOneName.Size = New System.Drawing.Size(265, 33)
        Me.leftOneName.TabIndex = 10
        '
        'rightOneName
        '
        Me.rightOneName.DropDownWidth = 200
        Me.rightOneName.FormattingEnabled = True
        Me.rightOneName.Items.AddRange(New Object() {"No Change", "Bare", "Caestus", "Claw", "Dark Hand", "Dragon Bone Fist", "Blacksmith Giant Hammer", "Blacksmith Hammer", "Hammer of Vamos", "Club", "Mace", "Morning Star", "Pickaxe", "Reinforced Club", "Warpick", "Demon's Great Hammer", "Dragon Tooth", "Grant", "Great Club", "Large Club", "Smough's Hammer", "Battle Axe", "Butcher Knife", "Crescent Axe", "Gargoyle Tail Axe", "Golem Axe", "Hand Axe", "Black Knight Greataxe", "Demon's Greataxe", "Dragon King Greataxe", "Greataxe", "Stone Greataxe", "Bandit's Knife", "Dagger", "Dark Silver Tracer", "Ghost Blade", "Parrying Dagger", "Priscilla's Dagger", "Estoc", "Mail Breaker", "Rapier", "Ricard's Rapier", "Velka's Rapier", "Astora's Straight Sword", "Balder Side Sword", "Barbed Straight Sword", "Broad Sword", "Broken Straight Sword", "Crystal Straight Sword", "Dark Sword", "Drake Sword", "Longsword", "Shortsword", "Silver Knight Straight Sword", "Straight Sword Hilt", "Sunlight Straight Sword", "Abyss Greatsword", "Bastard Sword", "Black Knight Sword", "Claymore", "Crystal Greatsword", "Flamberge", "Great Lord Greatsword", "Greatsword of Artorias", "Greatsword of Artorias (Cursed)", "Man Serpent Greatsword", "Moonlight Greatsword", "Obsidian Greatsword", "Stone Greatsword", "Black Knight Greatsword", "Demon Great Machete", "Dragon Greatsword", "Greatsword", "Zweihander", "Chaos Blade", "Iaito", "Uchigatana", "Washing Pole", "Falchion", "Gold Tracer", "Jagged Ghost Blade", "Painting Guardian Sword", "Quelaag's Fury Sword", "Scimitar", "Shotel", "Gravelord Sword", "Murakumo", "Server", "Channeler's Trident", "Demon's Spear", "Dragonslayer Spear", "Four-Pronged Plow", "Moonlight Butterfly Horn", "Partizan", "Pike", "Silver Knight Spear", "Spear", "Winged Spear", "Black Knight Halberd", "Gargoyle's Halberd", "Giant's Halberd", "Great Scythe", "Halberd", "Lifehunt Scythe", "Lucerne", "Scythe", "Titanite Catch Pole", "Black Bow of Pharis", "Composite Bow", "Darkmoon Bow", "Long Bow", "Short Bow", "Avelyn", "Heavy Crossbow", "Light Crossbow", "Sniper Crossbow", "Dragonslayer Greatbow", "Gough's Greatbow", "Guardian Tail", "Notched Whip", "Whip", "Beatrice's Catalyst", "Demon's Catalyst", "Izalith Catalyst", "Logan's Catalyst", "Manus Catalyst", "Oolacile Catalyst", "Oolacile Ivory Catalyst", "Sorcerer's Catalyst", "Tin Banishment Catalyst", "Tin Crystallization Catalyst", "Tin Darkmoon Catalyst", "Canvas Talisman", "Darkmoon Talisman", "Ivory Talisman", "Sunlight Talisman", "Talisman", "Thorolund Talisman", "Velka's Talisman", "Skull Lantern", "Ascended Pyromancy Flame", "Pyromancy Flame", "Buckler", "Caduceus Round Shield", "Cracked Round Shield", "Effigy Shield", "Leather Shield", "Plank Shield", "Red and White Round Shield", "Small Leather Shield", "Target Shield", "Warrior's Round Shield", "Balder Shield", "Black Knight Shield", "Bloodshield", "Caduceus Kite Shield", "Crest Shield", "Dragon Crest Shield", "East-West Shield", "Gargoyle's Shield", "Grass Crest Shield", "Heater Shield", "Hollow Soldier Shield", "Iron Round Shield", "Knight Shield", "Large Leather Shield", "Sanctus", "Silver Knight Shield", "Spider Shield", "Sunlight Shield", "Tower Kite Shield", "Wooden Shield", "Black Iron Greatshield", "Bonewheel Shield", "Cleansing Greatshield", "Eagle Shield", "Giant Shield", "Greatshield of Artorias", "Havel's Greatshield", "Stone Greatshield", "Tower Shield", "Crystal Ring Shield", "Crystal Shield", "Spiked Shield", "Pierce Shield", "Dark Hand"})
        Me.rightOneName.Location = New System.Drawing.Point(244, 168)
        Me.rightOneName.Margin = New System.Windows.Forms.Padding(4)
        Me.rightOneName.Name = "rightOneName"
        Me.rightOneName.Size = New System.Drawing.Size(265, 33)
        Me.rightOneName.TabIndex = 4
        '
        'leftTwoName
        '
        Me.leftTwoName.DropDownWidth = 200
        Me.leftTwoName.FormattingEnabled = True
        Me.leftTwoName.Items.AddRange(New Object() {"No Change", "Bare", "Caestus", "Claw", "Dark Hand", "Dragon Bone Fist", "Blacksmith Giant Hammer", "Blacksmith Hammer", "Hammer of Vamos", "Club", "Mace", "Morning Star", "Pickaxe", "Reinforced Club", "Warpick", "Demon's Great Hammer", "Dragon Tooth", "Grant", "Great Club", "Large Club", "Smough's Hammer", "Battle Axe", "Butcher Knife", "Crescent Axe", "Gargoyle Tail Axe", "Golem Axe", "Hand Axe", "Black Knight Greataxe", "Demon's Greataxe", "Dragon King Greataxe", "Greataxe", "Stone Greataxe", "Bandit's Knife", "Dagger", "Dark Silver Tracer", "Ghost Blade", "Parrying Dagger", "Priscilla's Dagger", "Estoc", "Mail Breaker", "Rapier", "Ricard's Rapier", "Velka's Rapier", "Astora's Straight Sword", "Balder Side Sword", "Barbed Straight Sword", "Broad Sword", "Broken Straight Sword", "Crystal Straight Sword", "Dark Sword", "Drake Sword", "Longsword", "Shortsword", "Silver Knight Straight Sword", "Straight Sword Hilt", "Sunlight Straight Sword", "Abyss Greatsword", "Bastard Sword", "Black Knight Sword", "Claymore", "Crystal Greatsword", "Flamberge", "Great Lord Greatsword", "Greatsword of Artorias", "Greatsword of Artorias (Cursed)", "Man Serpent Greatsword", "Moonlight Greatsword", "Obsidian Greatsword", "Stone Greatsword", "Black Knight Greatsword", "Demon Great Machete", "Dragon Greatsword", "Greatsword", "Zweihander", "Chaos Blade", "Iaito", "Uchigatana", "Washing Pole", "Falchion", "Gold Tracer", "Jagged Ghost Blade", "Painting Guardian Sword", "Quelaag's Fury Sword", "Scimitar", "Shotel", "Gravelord Sword", "Murakumo", "Server", "Channeler's Trident", "Demon's Spear", "Dragonslayer Spear", "Four-Pronged Plow", "Moonlight Butterfly Horn", "Partizan", "Pike", "Silver Knight Spear", "Spear", "Winged Spear", "Black Knight Halberd", "Gargoyle's Halberd", "Giant's Halberd", "Great Scythe", "Halberd", "Lifehunt Scythe", "Lucerne", "Scythe", "Titanite Catch Pole", "Black Bow of Pharis", "Composite Bow", "Darkmoon Bow", "Long Bow", "Short Bow", "Avelyn", "Heavy Crossbow", "Light Crossbow", "Sniper Crossbow", "Dragonslayer Greatbow", "Gough's Greatbow", "Guardian Tail", "Notched Whip", "Whip", "Beatrice's Catalyst", "Demon's Catalyst", "Izalith Catalyst", "Logan's Catalyst", "Manus Catalyst", "Oolacile Catalyst", "Oolacile Ivory Catalyst", "Sorcerer's Catalyst", "Tin Banishment Catalyst", "Tin Crystallization Catalyst", "Tin Darkmoon Catalyst", "Canvas Talisman", "Darkmoon Talisman", "Ivory Talisman", "Sunlight Talisman", "Talisman", "Thorolund Talisman", "Velka's Talisman", "Skull Lantern", "Ascended Pyromancy Flame", "Pyromancy Flame", "Buckler", "Caduceus Round Shield", "Cracked Round Shield", "Effigy Shield", "Leather Shield", "Plank Shield", "Red and White Round Shield", "Small Leather Shield", "Target Shield", "Warrior's Round Shield", "Balder Shield", "Black Knight Shield", "Bloodshield", "Caduceus Kite Shield", "Crest Shield", "Dragon Crest Shield", "East-West Shield", "Gargoyle's Shield", "Grass Crest Shield", "Heater Shield", "Hollow Soldier Shield", "Iron Round Shield", "Knight Shield", "Large Leather Shield", "Sanctus", "Silver Knight Shield", "Spider Shield", "Sunlight Shield", "Tower Kite Shield", "Wooden Shield", "Black Iron Greatshield", "Bonewheel Shield", "Cleansing Greatshield", "Eagle Shield", "Giant Shield", "Greatshield of Artorias", "Havel's Greatshield", "Stone Greatshield", "Tower Shield", "Crystal Ring Shield", "Crystal Shield", "Spiked Shield", "Pierce Shield", "Dark Hand"})
        Me.leftTwoName.Location = New System.Drawing.Point(520, 402)
        Me.leftTwoName.Margin = New System.Windows.Forms.Padding(4)
        Me.leftTwoName.Name = "leftTwoName"
        Me.leftTwoName.Size = New System.Drawing.Size(265, 33)
        Me.leftTwoName.TabIndex = 13
        '
        'rightTwoName
        '
        Me.rightTwoName.DropDownWidth = 200
        Me.rightTwoName.FormattingEnabled = True
        Me.rightTwoName.Items.AddRange(New Object() {"No Change", "Bare", "Caestus", "Claw", "Dark Hand", "Dragon Bone Fist", "Blacksmith Giant Hammer", "Blacksmith Hammer", "Hammer of Vamos", "Club", "Mace", "Morning Star", "Pickaxe", "Reinforced Club", "Warpick", "Demon's Great Hammer", "Dragon Tooth", "Grant", "Great Club", "Large Club", "Smough's Hammer", "Battle Axe", "Butcher Knife", "Crescent Axe", "Gargoyle Tail Axe", "Golem Axe", "Hand Axe", "Black Knight Greataxe", "Demon's Greataxe", "Dragon King Greataxe", "Greataxe", "Stone Greataxe", "Bandit's Knife", "Dagger", "Dark Silver Tracer", "Ghost Blade", "Parrying Dagger", "Priscilla's Dagger", "Estoc", "Mail Breaker", "Rapier", "Ricard's Rapier", "Velka's Rapier", "Astora's Straight Sword", "Balder Side Sword", "Barbed Straight Sword", "Broad Sword", "Broken Straight Sword", "Crystal Straight Sword", "Dark Sword", "Drake Sword", "Longsword", "Shortsword", "Silver Knight Straight Sword", "Straight Sword Hilt", "Sunlight Straight Sword", "Abyss Greatsword", "Bastard Sword", "Black Knight Sword", "Claymore", "Crystal Greatsword", "Flamberge", "Great Lord Greatsword", "Greatsword of Artorias", "Greatsword of Artorias (Cursed)", "Man Serpent Greatsword", "Moonlight Greatsword", "Obsidian Greatsword", "Stone Greatsword", "Black Knight Greatsword", "Demon Great Machete", "Dragon Greatsword", "Greatsword", "Zweihander", "Chaos Blade", "Iaito", "Uchigatana", "Washing Pole", "Falchion", "Gold Tracer", "Jagged Ghost Blade", "Painting Guardian Sword", "Quelaag's Fury Sword", "Scimitar", "Shotel", "Gravelord Sword", "Murakumo", "Server", "Channeler's Trident", "Demon's Spear", "Dragonslayer Spear", "Four-Pronged Plow", "Moonlight Butterfly Horn", "Partizan", "Pike", "Silver Knight Spear", "Spear", "Winged Spear", "Black Knight Halberd", "Gargoyle's Halberd", "Giant's Halberd", "Great Scythe", "Halberd", "Lifehunt Scythe", "Lucerne", "Scythe", "Titanite Catch Pole", "Black Bow of Pharis", "Composite Bow", "Darkmoon Bow", "Long Bow", "Short Bow", "Avelyn", "Heavy Crossbow", "Light Crossbow", "Sniper Crossbow", "Dragonslayer Greatbow", "Gough's Greatbow", "Guardian Tail", "Notched Whip", "Whip", "Beatrice's Catalyst", "Demon's Catalyst", "Izalith Catalyst", "Logan's Catalyst", "Manus Catalyst", "Oolacile Catalyst", "Oolacile Ivory Catalyst", "Sorcerer's Catalyst", "Tin Banishment Catalyst", "Tin Crystallization Catalyst", "Tin Darkmoon Catalyst", "Canvas Talisman", "Darkmoon Talisman", "Ivory Talisman", "Sunlight Talisman", "Talisman", "Thorolund Talisman", "Velka's Talisman", "Skull Lantern", "Ascended Pyromancy Flame", "Pyromancy Flame", "Buckler", "Caduceus Round Shield", "Cracked Round Shield", "Effigy Shield", "Leather Shield", "Plank Shield", "Red and White Round Shield", "Small Leather Shield", "Target Shield", "Warrior's Round Shield", "Balder Shield", "Black Knight Shield", "Bloodshield", "Caduceus Kite Shield", "Crest Shield", "Dragon Crest Shield", "East-West Shield", "Gargoyle's Shield", "Grass Crest Shield", "Heater Shield", "Hollow Soldier Shield", "Iron Round Shield", "Knight Shield", "Large Leather Shield", "Sanctus", "Silver Knight Shield", "Spider Shield", "Sunlight Shield", "Tower Kite Shield", "Wooden Shield", "Black Iron Greatshield", "Bonewheel Shield", "Cleansing Greatshield", "Eagle Shield", "Giant Shield", "Greatshield of Artorias", "Havel's Greatshield", "Stone Greatshield", "Tower Shield", "Crystal Ring Shield", "Crystal Shield", "Spiked Shield", "Pierce Shield", "Dark Hand"})
        Me.rightTwoName.Location = New System.Drawing.Point(519, 168)
        Me.rightTwoName.Margin = New System.Windows.Forms.Padding(4)
        Me.rightTwoName.Name = "rightTwoName"
        Me.rightTwoName.Size = New System.Drawing.Size(265, 33)
        Me.rightTwoName.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(240, 586)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Helmet"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(515, 581)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 25)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Armor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(789, 582)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 25)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Gauntlets"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1064, 586)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 25)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Leggings"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(240, 368)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 25)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Left Weapon 1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(240, 135)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 25)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Right Weapon 1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(519, 370)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 25)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Left Weapon 2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(515, 135)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 25)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Right Weapon 2"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(61, 30)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 25)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Entity"
        '
        'applyButton
        '
        Me.applyButton.DialogResult = System.Windows.Forms.DialogResult.Retry
        Me.applyButton.Location = New System.Drawing.Point(16, 123)
        Me.applyButton.Margin = New System.Windows.Forms.Padding(4)
        Me.applyButton.Name = "applyButton"
        Me.applyButton.Size = New System.Drawing.Size(160, 48)
        Me.applyButton.TabIndex = 1
        Me.applyButton.Text = "Apply"
        Me.applyButton.UseVisualStyleBackColor = True
        '
        'helmetLevel
        '
        Me.helmetLevel.FormattingEnabled = True
        Me.helmetLevel.Items.AddRange(New Object() {"+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15"})
        Me.helmetLevel.Location = New System.Drawing.Point(245, 670)
        Me.helmetLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.helmetLevel.Name = "helmetLevel"
        Me.helmetLevel.Size = New System.Drawing.Size(99, 33)
        Me.helmetLevel.TabIndex = 17
        '
        'armorLevel
        '
        Me.armorLevel.FormattingEnabled = True
        Me.armorLevel.Items.AddRange(New Object() {"+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15"})
        Me.armorLevel.Location = New System.Drawing.Point(520, 670)
        Me.armorLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.armorLevel.Name = "armorLevel"
        Me.armorLevel.Size = New System.Drawing.Size(99, 33)
        Me.armorLevel.TabIndex = 19
        '
        'gauntletsLevel
        '
        Me.gauntletsLevel.FormattingEnabled = True
        Me.gauntletsLevel.Items.AddRange(New Object() {"+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15"})
        Me.gauntletsLevel.Location = New System.Drawing.Point(795, 669)
        Me.gauntletsLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.gauntletsLevel.Name = "gauntletsLevel"
        Me.gauntletsLevel.Size = New System.Drawing.Size(99, 33)
        Me.gauntletsLevel.TabIndex = 21
        '
        'leggingsLevel
        '
        Me.leggingsLevel.FormattingEnabled = True
        Me.leggingsLevel.Items.AddRange(New Object() {"+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15"})
        Me.leggingsLevel.Location = New System.Drawing.Point(1069, 669)
        Me.leggingsLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.leggingsLevel.Name = "leggingsLevel"
        Me.leggingsLevel.Size = New System.Drawing.Size(99, 33)
        Me.leggingsLevel.TabIndex = 23
        '
        'leftOneLevel
        '
        Me.leftOneLevel.FormattingEnabled = True
        Me.leftOneLevel.Items.AddRange(New Object() {"+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15"})
        Me.leftOneLevel.Location = New System.Drawing.Point(245, 456)
        Me.leftOneLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.leftOneLevel.Name = "leftOneLevel"
        Me.leftOneLevel.Size = New System.Drawing.Size(99, 33)
        Me.leftOneLevel.TabIndex = 11
        '
        'rightOneLevel
        '
        Me.rightOneLevel.FormattingEnabled = True
        Me.rightOneLevel.Items.AddRange(New Object() {"+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15"})
        Me.rightOneLevel.Location = New System.Drawing.Point(245, 222)
        Me.rightOneLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.rightOneLevel.Name = "rightOneLevel"
        Me.rightOneLevel.Size = New System.Drawing.Size(99, 33)
        Me.rightOneLevel.TabIndex = 5
        '
        'LeftTwoLevel
        '
        Me.LeftTwoLevel.FormattingEnabled = True
        Me.LeftTwoLevel.Items.AddRange(New Object() {"+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15"})
        Me.LeftTwoLevel.Location = New System.Drawing.Point(520, 456)
        Me.LeftTwoLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.LeftTwoLevel.Name = "LeftTwoLevel"
        Me.LeftTwoLevel.Size = New System.Drawing.Size(99, 33)
        Me.LeftTwoLevel.TabIndex = 14
        '
        'rightTwoLevel
        '
        Me.rightTwoLevel.FormattingEnabled = True
        Me.rightTwoLevel.Items.AddRange(New Object() {"+0", "+1", "+2", "+3", "+4", "+5", "+6", "+7", "+8", "+9", "+10", "+11", "+12", "+13", "+14", "+15"})
        Me.rightTwoLevel.Location = New System.Drawing.Point(519, 222)
        Me.rightTwoLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.rightTwoLevel.Name = "rightTwoLevel"
        Me.rightTwoLevel.Size = New System.Drawing.Size(99, 33)
        Me.rightTwoLevel.TabIndex = 8
        '
        'leftOneInfusion
        '
        Me.leftOneInfusion.FormattingEnabled = True
        Me.leftOneInfusion.Items.AddRange(New Object() {"Standard/None", "Crystal", "Lightning", "Raw", "Magic", "Enchanged", "Divine", "Occult", "Fire", "Chaos"})
        Me.leftOneInfusion.Location = New System.Drawing.Point(245, 515)
        Me.leftOneInfusion.Margin = New System.Windows.Forms.Padding(4)
        Me.leftOneInfusion.Name = "leftOneInfusion"
        Me.leftOneInfusion.Size = New System.Drawing.Size(172, 33)
        Me.leftOneInfusion.TabIndex = 12
        '
        'rightOneInfusion
        '
        Me.rightOneInfusion.FormattingEnabled = True
        Me.rightOneInfusion.Items.AddRange(New Object() {"Standard/None", "Crystal", "Lightning", "Raw", "Magic", "Enchanged", "Divine", "Occult", "Fire", "Chaos"})
        Me.rightOneInfusion.Location = New System.Drawing.Point(245, 281)
        Me.rightOneInfusion.Margin = New System.Windows.Forms.Padding(4)
        Me.rightOneInfusion.Name = "rightOneInfusion"
        Me.rightOneInfusion.Size = New System.Drawing.Size(172, 33)
        Me.rightOneInfusion.TabIndex = 6
        '
        'leftTwoInfusion
        '
        Me.leftTwoInfusion.FormattingEnabled = True
        Me.leftTwoInfusion.Items.AddRange(New Object() {"Standard/None", "Crystal", "Lightning", "Raw", "Magic", "Enchanged", "Divine", "Occult", "Fire", "Chaos"})
        Me.leftTwoInfusion.Location = New System.Drawing.Point(520, 514)
        Me.leftTwoInfusion.Margin = New System.Windows.Forms.Padding(4)
        Me.leftTwoInfusion.Name = "leftTwoInfusion"
        Me.leftTwoInfusion.Size = New System.Drawing.Size(172, 33)
        Me.leftTwoInfusion.TabIndex = 15
        '
        'rightTwoInfusion
        '
        Me.rightTwoInfusion.FormattingEnabled = True
        Me.rightTwoInfusion.Items.AddRange(New Object() {"Standard/None", "Crystal", "Lightning", "Raw", "Magic", "Enchanged", "Divine", "Occult", "Fire", "Chaos"})
        Me.rightTwoInfusion.Location = New System.Drawing.Point(520, 281)
        Me.rightTwoInfusion.Margin = New System.Windows.Forms.Padding(4)
        Me.rightTwoInfusion.Name = "rightTwoInfusion"
        Me.rightTwoInfusion.Size = New System.Drawing.Size(172, 33)
        Me.rightTwoInfusion.TabIndex = 9
        '
        'exportButton
        '
        Me.exportButton.Location = New System.Drawing.Point(16, 415)
        Me.exportButton.Name = "exportButton"
        Me.exportButton.Size = New System.Drawing.Size(160, 39)
        Me.exportButton.TabIndex = 3
        Me.exportButton.Text = "Export"
        Me.exportButton.UseVisualStyleBackColor = True
        '
        'importButton
        '
        Me.importButton.Location = New System.Drawing.Point(16, 350)
        Me.importButton.Name = "importButton"
        Me.importButton.Size = New System.Drawing.Size(160, 43)
        Me.importButton.TabIndex = 2
        Me.importButton.Text = "Import"
        Me.importButton.UseVisualStyleBackColor = True
        '
        'vitSet
        '
        Me.vitSet.Location = New System.Drawing.Point(1069, 70)
        Me.vitSet.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.vitSet.Name = "vitSet"
        Me.vitSet.Size = New System.Drawing.Size(100, 31)
        Me.vitSet.TabIndex = 24
        '
        'atnSet
        '
        Me.atnSet.Location = New System.Drawing.Point(1069, 133)
        Me.atnSet.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.atnSet.Name = "atnSet"
        Me.atnSet.Size = New System.Drawing.Size(100, 31)
        Me.atnSet.TabIndex = 25
        '
        'endSet
        '
        Me.endSet.Location = New System.Drawing.Point(1068, 195)
        Me.endSet.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.endSet.Name = "endSet"
        Me.endSet.Size = New System.Drawing.Size(100, 31)
        Me.endSet.TabIndex = 26
        '
        'strSet
        '
        Me.strSet.Location = New System.Drawing.Point(1069, 254)
        Me.strSet.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.strSet.Name = "strSet"
        Me.strSet.Size = New System.Drawing.Size(100, 31)
        Me.strSet.TabIndex = 27
        '
        'dexSet
        '
        Me.dexSet.Location = New System.Drawing.Point(1069, 315)
        Me.dexSet.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.dexSet.Name = "dexSet"
        Me.dexSet.Size = New System.Drawing.Size(100, 31)
        Me.dexSet.TabIndex = 28
        '
        'resSet
        '
        Me.resSet.Location = New System.Drawing.Point(1069, 370)
        Me.resSet.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.resSet.Name = "resSet"
        Me.resSet.Size = New System.Drawing.Size(100, 31)
        Me.resSet.TabIndex = 29
        '
        'intSet
        '
        Me.intSet.Location = New System.Drawing.Point(1069, 423)
        Me.intSet.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.intSet.Name = "intSet"
        Me.intSet.Size = New System.Drawing.Size(100, 31)
        Me.intSet.TabIndex = 30
        '
        'fthSet
        '
        Me.fthSet.Location = New System.Drawing.Point(1069, 478)
        Me.fthSet.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.fthSet.Name = "fthSet"
        Me.fthSet.Size = New System.Drawing.Size(100, 31)
        Me.fthSet.TabIndex = 31
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(944, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 25)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Vitality"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(944, 195)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(116, 25)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Endurance"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(944, 139)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(121, 25)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Attunement"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(944, 260)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 25)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Strength"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(944, 321)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 25)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "Dexterity"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(944, 376)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(119, 25)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Resistance"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(944, 429)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 25)
        Me.Label16.TabIndex = 49
        Me.Label16.Text = "Intelligence"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(944, 484)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 25)
        Me.Label17.TabIndex = 50
        Me.Label17.Text = "Faith"
        '
        'CosplayEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1400, 756)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.fthSet)
        Me.Controls.Add(Me.intSet)
        Me.Controls.Add(Me.resSet)
        Me.Controls.Add(Me.dexSet)
        Me.Controls.Add(Me.strSet)
        Me.Controls.Add(Me.endSet)
        Me.Controls.Add(Me.atnSet)
        Me.Controls.Add(Me.vitSet)
        Me.Controls.Add(Me.importButton)
        Me.Controls.Add(Me.exportButton)
        Me.Controls.Add(Me.rightTwoInfusion)
        Me.Controls.Add(Me.leftTwoInfusion)
        Me.Controls.Add(Me.rightOneInfusion)
        Me.Controls.Add(Me.leftOneInfusion)
        Me.Controls.Add(Me.rightTwoLevel)
        Me.Controls.Add(Me.LeftTwoLevel)
        Me.Controls.Add(Me.rightOneLevel)
        Me.Controls.Add(Me.leftOneLevel)
        Me.Controls.Add(Me.leggingsLevel)
        Me.Controls.Add(Me.gauntletsLevel)
        Me.Controls.Add(Me.armorLevel)
        Me.Controls.Add(Me.helmetLevel)
        Me.Controls.Add(Me.applyButton)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rightTwoName)
        Me.Controls.Add(Me.leftTwoName)
        Me.Controls.Add(Me.rightOneName)
        Me.Controls.Add(Me.leftOneName)
        Me.Controls.Add(Me.leggingsName)
        Me.Controls.Add(Me.gauntletsName)
        Me.Controls.Add(Me.armorName)
        Me.Controls.Add(Me.helmetName)
        Me.Controls.Add(Me.entityBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CosplayEditor"
        Me.Text = "CosplayEditor"
        CType(Me.vitSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.atnSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.endSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.strSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dexSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.resSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.intSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fthSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents entityBox As ComboBox
    Friend WithEvents helmetName As ComboBox
    Friend WithEvents armorName As ComboBox
    Friend WithEvents gauntletsName As ComboBox
    Friend WithEvents leggingsName As ComboBox
    Friend WithEvents leftOneName As ComboBox
    Friend WithEvents rightOneName As ComboBox
    Friend WithEvents leftTwoName As ComboBox
    Friend WithEvents rightTwoName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents applyButton As Button
    Friend WithEvents helmetLevel As ComboBox
    Friend WithEvents armorLevel As ComboBox
    Friend WithEvents gauntletsLevel As ComboBox
    Friend WithEvents leggingsLevel As ComboBox
    Friend WithEvents leftOneLevel As ComboBox
    Friend WithEvents rightOneLevel As ComboBox
    Friend WithEvents LeftTwoLevel As ComboBox
    Friend WithEvents rightTwoLevel As ComboBox
    Friend WithEvents leftOneInfusion As ComboBox
    Friend WithEvents rightOneInfusion As ComboBox
    Friend WithEvents leftTwoInfusion As ComboBox
    Friend WithEvents rightTwoInfusion As ComboBox
    Friend WithEvents exportButton As Button
    Friend WithEvents importButton As Button
    Friend WithEvents vitSet As NumericUpDown
    Friend WithEvents atnSet As NumericUpDown
    Friend WithEvents endSet As NumericUpDown
    Friend WithEvents strSet As NumericUpDown
    Friend WithEvents dexSet As NumericUpDown
    Friend WithEvents resSet As NumericUpDown
    Friend WithEvents intSet As NumericUpDown
    Friend WithEvents fthSet As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
End Class
