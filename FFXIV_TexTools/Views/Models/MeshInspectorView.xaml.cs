﻿// Copyright © 2019 Rafael Gonzalez - All Rights Reserved
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using xivModdingFramework.Models.DataContainers;


namespace FFXIV_TexTools.Views.Models
{
    /// <summary>
    /// Interaction logic for MeshInspectorView.xaml
    /// </summary>
    public partial class MeshInspectorView
    {
        private List<MeshData> _meshDataList;

        public MeshInspectorView(List<MeshData> meshDataList, int LodNum)
        {
            InitializeComponent();

            Title = $"Mesh Inspector (LoD {LodNum})";

            _meshDataList = meshDataList;

            FillMeshNumComboBox();
        }

        /// <summary>
        /// Fills the combobox with the numbers of available meshes
        /// </summary>
        private void FillMeshNumComboBox()
        {
            var meshNumList = new List<int>();

            for (var i = 0; i < _meshDataList.Count; i++)
            {
                meshNumList.Add(i);
            }

            MeshNumComboBox.ItemsSource = meshNumList;

            MeshNumComboBox.SelectedIndex = 0;
        }


        /// <summary>
        /// Event handler for mesh number changing
        /// </summary>
        private void MeshNumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MeshMetaDataRichTextBox.Document.Blocks.Clear();

            var selectedMeshNum = (int)MeshNumComboBox.SelectedItem;

            var mesh = _meshDataList[selectedMeshNum].MeshInfo;

            var textBox = MeshMetaDataRichTextBox;

            // Vertex Count
            AddText(textBox, "Vertex Count:\t\t", "Black", false);
            AddText(textBox, $"{mesh.VertexCount}\n\n", "Black", true);

            // Index Count
            AddText(textBox, "Index Count:\t\t", "Black", false);
            AddText(textBox, $"{mesh.IndexCount}\n\n", "Black", true);

            // Material Index
            AddText(textBox, "Material Index:\t", "Black", false);
            AddText(textBox, $"{mesh.MaterialIndex}\n\n", "Black", true);

            // Mesh Part Index
            AddText(textBox, "Mesh Part Index:\t", "Black", false);
            AddText(textBox, $"{mesh.MeshPartIndex}\n\n", "Black", true);

            // Mesh Part Count
            AddText(textBox, "Mesh Part Count:\t", "Black", false);
            AddText(textBox, $"{mesh.MeshPartCount}\n\n", "Black", true);

            // Bone List Index
            AddText(textBox, "Bone List Index:\t", "Black", false);
            AddText(textBox, $"{mesh.BoneListIndex}\n\n", "Black", true);

            // Index Data Offset
            AddText(textBox, "Index Data Offset:\t", "Black", false);
            AddText(textBox, $"{mesh.IndexDataOffset}\n\n", "Black", true);

            // Vertex Data Offset 0
            AddText(textBox, "Vertex Data Offset 0:\t", "Black", false);
            AddText(textBox, $"{mesh.VertexDataOffset0}\n\n", "Black", true);

            // Vertex Data Offset 1
            AddText(textBox, "Vertex Data Offset 1:\t", "Black", false);
            AddText(textBox, $"{mesh.VertexDataOffset1}\n\n", "Black", true);

            // Vertex Data Offset 2
            AddText(textBox, "Vertex Data Offset 2:\t", "Black", false);
            AddText(textBox, $"{mesh.VertexDataOffset2}\n\n", "Black", true);

            // Vertex Entry Size 0
            AddText(textBox, "Vertex Entry Size 0:\t", "Black", false);
            AddText(textBox, $"{mesh.VertexDataEntrySize0}\n\n", "Black", true);

            // Vertex Entry Size 1
            AddText(textBox, "Vertex Entry Size 1:\t", "Black", false);
            AddText(textBox, $"{mesh.VertexDataEntrySize1}\n\n", "Black", true);

            // Vertex Entry Size 2
            AddText(textBox, "Vertex Entry Size 2:\t", "Black", false);
            AddText(textBox, $"{mesh.VertexDataEntrySize2}\n\n", "Black", true);

            // Vertex Data Block Count
            AddText(textBox, "Data Block Count:\t", "Black", false);
            AddText(textBox, $"{mesh.VertexDataBlockCount}\n\n", "Black", true);


            FillMeshPartComboBox();
            FillVertexStructComboBox();
        }

        /// <summary>
        /// Fills the combobox with available mesh parts
        /// </summary>
        private void FillMeshPartComboBox()
        {
            var selectedMeshNum = (int)MeshNumComboBox.SelectedItem;

            var mesh = _meshDataList[selectedMeshNum].MeshInfo;

            var meshPartNums = new List<int>();

            for (var i = 0; i < mesh.MeshPartCount; i++)
            {
                meshPartNums.Add(i);
            }

            PartNumComboBox.ItemsSource = meshPartNums;

            PartNumComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Event handler for mesh part number changing
        /// </summary>
        private void PartNumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MeshPartsRichTextBox.Document.Blocks.Clear();

            var selectedMeshNum = (int)MeshNumComboBox.SelectedItem;
            var selectedPartNum = (int)PartNumComboBox.SelectedItem;

            var meshPart = _meshDataList[selectedMeshNum].MeshPartList[selectedPartNum];

            var textBox = MeshPartsRichTextBox;

            // Index Offset
            AddText(textBox, "Index Offset:\t\t", "Black", false);
            AddText(textBox, $"{meshPart.IndexOffset}\n\n", "Black", true);

            // Index Count
            AddText(textBox, "Index Count:\t\t", "Black", false);
            AddText(textBox, $"{meshPart.IndexCount}\n\n", "Black", true);

            // Attribute Index
            AddText(textBox, "Attribute Index:\t", "Black", false);
            AddText(textBox, $"{meshPart.AttributeIndex}\n\n", "Black", true);

            // Bone Start Offset
            AddText(textBox, "Bone Start Offset:\t", "Black", false);
            AddText(textBox, $"{meshPart.BoneStartOffset}\n\n", "Black", true);

            // Bone Count
            AddText(textBox, "Bone Count:\t\t", "Black", false);
            AddText(textBox, $"{meshPart.BoneCount}\n\n", "Black", true);
        }

        /// <summary>
        /// Fills the combo box with available vertex structures
        /// </summary>
        private void FillVertexStructComboBox()
        {
            var selectedMeshNum = (int)MeshNumComboBox.SelectedItem;

            var mesh = _meshDataList[selectedMeshNum];

            var vertexStructList = mesh.VertexDataStructList;

            var vertexStructNumList = new List<int>();

            for (var i = 0; i < vertexStructList.Count; i++)
            {
                vertexStructNumList.Add(i);
            }

            StructNumComboBox.ItemsSource = vertexStructNumList;

            StructNumComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Event handler for vertex structure changing
        /// </summary>
        private void StructNumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataStructRichTextBox.Document.Blocks.Clear();

            var selectedStructNum = (int) StructNumComboBox.SelectedItem;

            var selectedMeshNum = (int)MeshNumComboBox.SelectedItem;

            var mesh = _meshDataList[selectedMeshNum];

            var vertexStruct = mesh.VertexDataStructList[selectedStructNum];

            var textBox = DataStructRichTextBox;

            // Data Block
            AddText(textBox, "Data Block:\t\t", "Black", false);
            AddText(textBox, $"{vertexStruct.DataBlock}\n\n", "Black", true);

            // Data Offset
            AddText(textBox, "Data Offset:\t\t", "Black", false);
            AddText(textBox, $"{vertexStruct.DataOffset}\n\n", "Black", true);

            // Data Type
            AddText(textBox, "Data Type:\t\t", "Black", false);
            AddText(textBox, $"{vertexStruct.DataType}\n\n", "Black", true);

            // Data Usage
            AddText(textBox, "Data Usage:\t\t", "Black", false);
            AddText(textBox, $"{vertexStruct.DataUsage}\n\n", "Black", true);
        }


        /// <summary>
        /// Adds text to the text box
        /// </summary>
        /// <param name="text">The text to add</param>
        /// <param name="color">The color of the text</param>
        private void AddText(RichTextBox richTextBox, string text, string color, bool bold)
        {
            var bc = new BrushConverter();
            var tr = new TextRange(richTextBox.Document.ContentEnd, richTextBox.Document.ContentEnd) { Text = text };
            try
            {
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, bc.ConvertFromString(color));

                if (bold)
                {
                    tr.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                }
            }
            catch (FormatException) { }
        }

        /// <summary>
        /// Event handler for the window closing
        /// </summary>
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Activate();
        }
    }
}
