#pragma once

namespace 算法实现题08 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Form1 摘要
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: 在此处添加构造函数代码
			//
		}

	protected:
		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::TextBox^  InputTextBox;
	private: System::Windows::Forms::TextBox^  OutputTextBox;
	private: System::Windows::Forms::Button^  openFileBtn;
	private: System::Windows::Forms::Button^  saveFileBtn;
	private: System::Windows::Forms::Button^  resetBtn;
	private: System::Windows::Forms::Button^  startBtn;




	private: System::Windows::Forms::GroupBox^  groupBox1;
	private: System::Windows::Forms::GroupBox^  groupBox2;
	private: System::Windows::Forms::TextBox^  outputArea;
	protected: 

	private:
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->InputTextBox = (gcnew System::Windows::Forms::TextBox());
			this->OutputTextBox = (gcnew System::Windows::Forms::TextBox());
			this->openFileBtn = (gcnew System::Windows::Forms::Button());
			this->saveFileBtn = (gcnew System::Windows::Forms::Button());
			this->resetBtn = (gcnew System::Windows::Forms::Button());
			this->startBtn = (gcnew System::Windows::Forms::Button());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->groupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->outputArea = (gcnew System::Windows::Forms::TextBox());
			this->groupBox1->SuspendLayout();
			this->groupBox2->SuspendLayout();
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(16, 48);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(211, 15);
			this->label1->TabIndex = 0;
			this->label1->Text = L"输入数据:(数字间用空格分开)";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(16, 264);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(196, 15);
			this->label2->TabIndex = 1;
			this->label2->Text = L"输出数据:(按从小到大排序)";
			// 
			// InputTextBox
			// 
			this->InputTextBox->Location = System::Drawing::Point(16, 72);
			this->InputTextBox->Multiline = true;
			this->InputTextBox->Name = L"InputTextBox";
			this->InputTextBox->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
			this->InputTextBox->Size = System::Drawing::Size(288, 80);
			this->InputTextBox->TabIndex = 2;
			// 
			// OutputTextBox
			// 
			this->OutputTextBox->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->OutputTextBox->Location = System::Drawing::Point(16, 288);
			this->OutputTextBox->Multiline = true;
			this->OutputTextBox->Name = L"OutputTextBox";
			this->OutputTextBox->ReadOnly = true;
			this->OutputTextBox->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
			this->OutputTextBox->Size = System::Drawing::Size(288, 80);
			this->OutputTextBox->TabIndex = 3;
			// 
			// openFileBtn
			// 
			this->openFileBtn->Location = System::Drawing::Point(176, 168);
			this->openFileBtn->Name = L"openFileBtn";
			this->openFileBtn->Size = System::Drawing::Size(128, 31);
			this->openFileBtn->TabIndex = 4;
			this->openFileBtn->Text = L"导入数据...";
			this->openFileBtn->UseVisualStyleBackColor = true;
			this->openFileBtn->Click += gcnew System::EventHandler(this, &Form1::openFileBtn_Click);
			// 
			// saveFileBtn
			// 
			this->saveFileBtn->Location = System::Drawing::Point(176, 384);
			this->saveFileBtn->Name = L"saveFileBtn";
			this->saveFileBtn->Size = System::Drawing::Size(128, 32);
			this->saveFileBtn->TabIndex = 5;
			this->saveFileBtn->Text = L"导出数据...";
			this->saveFileBtn->UseVisualStyleBackColor = true;
			this->saveFileBtn->Click += gcnew System::EventHandler(this, &Form1::saveFileBtn_Click);
			// 
			// resetBtn
			// 
			this->resetBtn->Location = System::Drawing::Point(16, 480);
			this->resetBtn->Name = L"resetBtn";
			this->resetBtn->Size = System::Drawing::Size(120, 39);
			this->resetBtn->TabIndex = 6;
			this->resetBtn->Text = L"重置";
			this->resetBtn->UseVisualStyleBackColor = true;
			this->resetBtn->Click += gcnew System::EventHandler(this, &Form1::resetBtn_Click);
			// 
			// startBtn
			// 
			this->startBtn->Location = System::Drawing::Point(184, 480);
			this->startBtn->Name = L"startBtn";
			this->startBtn->Size = System::Drawing::Size(120, 39);
			this->startBtn->TabIndex = 7;
			this->startBtn->Text = L"开始排序";
			this->startBtn->UseVisualStyleBackColor = true;
			this->startBtn->Click += gcnew System::EventHandler(this, &Form1::startBtn_Click);
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->InputTextBox);
			this->groupBox1->Controls->Add(this->saveFileBtn);
			this->groupBox1->Controls->Add(this->startBtn);
			this->groupBox1->Controls->Add(this->label1);
			this->groupBox1->Controls->Add(this->resetBtn);
			this->groupBox1->Controls->Add(this->openFileBtn);
			this->groupBox1->Controls->Add(this->OutputTextBox);
			this->groupBox1->Controls->Add(this->label2);
			this->groupBox1->Location = System::Drawing::Point(32, 16);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(320, 536);
			this->groupBox1->TabIndex = 8;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"控制面板";
			// 
			// groupBox2
			// 
			this->groupBox2->Controls->Add(this->outputArea);
			this->groupBox2->Location = System::Drawing::Point(392, 16);
			this->groupBox2->Name = L"groupBox2";
			this->groupBox2->Size = System::Drawing::Size(584, 536);
			this->groupBox2->TabIndex = 9;
			this->groupBox2->TabStop = false;
			this->groupBox2->Text = L"输出过程";
			// 
			// outputArea
			// 
			this->outputArea->BackColor = System::Drawing::SystemColors::ButtonHighlight;
			this->outputArea->Location = System::Drawing::Point(16, 32);
			this->outputArea->Multiline = true;
			this->outputArea->Name = L"outputArea";
			this->outputArea->ReadOnly = true;
			this->outputArea->ScrollBars = System::Windows::Forms::ScrollBars::Both;
			this->outputArea->Size = System::Drawing::Size(552, 496);
			this->outputArea->TabIndex = 0;
			this->outputArea->WordWrap = false;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 15);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(992, 574);
			this->Controls->Add(this->groupBox2);
			this->Controls->Add(this->groupBox1);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
			this->MaximizeBox = false;
			this->Name = L"Form1";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"算法实现题08_堆的排序";
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->groupBox2->ResumeLayout(false);
			this->groupBox2->PerformLayout();
			this->ResumeLayout(false);

		}


		void HeapAdjust(array<int>^ ex,int s,int m)
		{
			int i,temp = ex[s];
			for(i = 2*s;i <= m;i *= 2)
			{
				if(i < m && ex[i] < ex[i+1])
					i++;
				if(temp >= ex[i])
					break;
				ex[s] = ex[i];
				s = i;
			}
			ex[s] = temp;
		}

		void HeapSort(array<int>^ ex,int len)
		{
			int i,temp;
			for(i = (int)len/2;i > 0;i--)
				HeapAdjust(ex,i,len);
			for(i = len;i > 1;i--)
			{
				temp = ex[1];
				ex[1] = ex[i];
				ex[i] = temp;
				display(ex,i);
			}
		}

		//输出堆排序的输出元素以及剩下的堆
		void display(array<int>^ ex, int i) 
		{
			String^ displayString = "堆顶元素：" + ex[i] + "\r\n";
			HeapAdjust(ex,1,i-1);
			displayString += "堆：\r\n";
			int u = 1,v,w = 1;
			int n = (int)(System::Math::Log(i)/System::Math::Log(2)) + 1;
			int level = 1;
			while(u <= i-1)
			{
				String^ tempString = "";
				String^ frontspaceString = tempString->PadLeft((int)(System::Math::Pow(2,n - level) - 1) * 2,' ');
				String^ btwspaceString = tempString->PadLeft((int)(System::Math::Pow(2,n - level + 1) - 1) * 2,' ');
				displayString += frontspaceString;
				for(v = 1;v <= w && u <= i-1;v ++)
				{
					displayString += ex[u++];
					displayString += btwspaceString;
				}
				w *= 2;
				level++;
				displayString += "\r\n";
			}
			this->outputArea->Text += displayString;
		}

		#pragma endregion

	//打开文件
	private: System::Void openFileBtn_Click(System::Object^  sender, System::EventArgs^  e) {
				 OpenFileDialog^ dlg = gcnew OpenFileDialog();
				 dlg->Filter = "文本文件(*.txt)|*.txt";
				 dlg->DefaultExt = "txt";
				 if (dlg->ShowDialog() != System::Windows::Forms::DialogResult::OK) return;
				 try {
					System::IO::StreamReader^ sr = gcnew System::IO::StreamReader(dlg->FileName, System::Text::Encoding::Default );
					this->InputTextBox->Text = nullptr;
					String^ str;
					str = sr->ReadToEnd();
					this->InputTextBox->Text = str;
					sr->Close();
				 }
				 catch(System::IO::IOException^ e) {
					MessageBox::Show(e->ToString());
				 }
			 }

	//保存排序后的数据
	private: System::Void saveFileBtn_Click(System::Object^  sender, System::EventArgs^  e) {
				 SaveFileDialog^ dlg = gcnew SaveFileDialog();
				 dlg->Filter = "文本文件(*.txt)|*.txt";
				 dlg->DefaultExt = "txt";
				 dlg->FileName = "*.txt";
				 if (dlg->ShowDialog() != System::Windows::Forms::DialogResult::OK) return;
				 try {
					System::IO::StreamWriter^ sw = gcnew System::IO::StreamWriter(dlg->FileName);
					String^ outputString = this->OutputTextBox->Text;
					sw->Write(outputString);
					sw->Flush();
					sw->Close();
				 }
				 catch(System::IO::IOException^ e) {
					MessageBox::Show(e->ToString());
				 }
		 }

	//重置
	private: System::Void resetBtn_Click(System::Object^  sender, System::EventArgs^  e) {
				 this->InputTextBox->Text = nullptr;
				 this->OutputTextBox->Text = nullptr;
				 this->outputArea->Text = nullptr;
		 }

	//开始排序
	private: System::Void startBtn_Click(System::Object^  sender, System::EventArgs^  e) {
				 String^ inputString = this->InputTextBox->Text + " ";
				 String^ tempString = "";
				 array<int>^ inputNums = gcnew array<int>(inputString->Length);
				 int count = 1;
				 for(int i = 0;i < inputString->Length;i++)
				 {
					 if(inputString[i] == ' ') {
						if(tempString != "") {
							int num = System::Convert::ToInt32(tempString);
							inputNums[count++] = num;
						}
						tempString = "";
					 }
					 else if(inputString[i] >= '0' && inputString[i] <= '9') {
						 tempString += inputString[i].ToString();
					 }
					 else {
						MessageBox::Show("输入数据含有非法字符！");
						return;
					 }
				 }
				 if(count == 1) {
					 MessageBox::Show("输入数据为空！");
					 return;
				 }
				 HeapSort(inputNums,count-1);
				 tempString = "";
				 for(int j = 1;j <= count-1;j++) {
					tempString += inputNums[j];
					if(j != count-1)
						tempString += " ";
				 }
				 this->OutputTextBox->Text = tempString;
		 }
};
}


