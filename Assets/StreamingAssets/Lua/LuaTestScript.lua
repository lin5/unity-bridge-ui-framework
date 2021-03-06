local Debug = CS.UnityEngine.Debug

function oninit()
	print("lua oninit...")
	slider_trans = self.transform:Find("Slider")
	slider = slider_trans:GetComponent(typeof(CS.UnityEngine.UI.Slider))
	slider.onValueChanged:AddListener(printprogress)
	self:SetValue("text","我是从lua中生成的文字")
	self:SetValue("image_color",CS.UnityEngine.Color(1,0,0,1))
end

function update()
	print("lua update...")
	self:SetValue("btn_color",CS.UnityEngine.Color(CS.UnityEngine.Time.time % 1,0.5,0.1,1))
end

function ondestroy()
    print("lua destroy")
end

function printprogress(f)
	print(f)
	end

function on_button_clicked(panel)
	buttonClicked = true
	print("lua on_button_clicked...")
	Debug.Log("(debug:)lua on_button_clicked...")
end

function on_toggle_switched(panel,isOn)
	print("lua on_toggle_switched...",isOn)
end

--下拉框
function on_dropdown_switched(panel,value)
	print("lua on_dropdown_switched...",value)
end

--输入框
function on_inputfield_edited(panel,text)
	print("lua on_inputfield_edited...",text)
end

--滑动框
function on_scrollview_changed(panel)
	print("lua on_scrollview_changed...")
end

function handle_data(data)
	print(data)
end