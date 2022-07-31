
#include <GL/glew.h>
#include <GLFW/glfw3.h>
#include <fstream>
#include <iomanip>
#include <filesystem>
#include <iostream>
#include <string>

using namespace std;
#define print(C) cout<<C<<endl
using std::filesystem::current_path;

static int compileShader(unsigned int type, const string& source) {
    unsigned int id =  glCreateShader(type);
    const char* src = source.c_str();
    glShaderSource(id,1,&src,nullptr);
    glCompileShader(id);
    int result;
    glGetShaderiv(id, GL_COMPILE_STATUS, &result); 
    if (result == GL_FALSE) {
        int length;
        glGetShaderiv(id, GL_INFO_LOG_LENGTH, &length);
        char* message = (char*)alloca(length * sizeof(char));
        glGetShaderInfoLog(id, length,&length, message);
        print(message);
    }
    return id;

}
static unsigned int CreateShader(const string& vertexSahder, const string& fragmentShader)
{
    unsigned int program = glCreateProgram();
    unsigned int vs = compileShader(GL_VERTEX_SHADER, vertexSahder);
    unsigned int fs = compileShader(GL_FRAGMENT_SHADER, fragmentShader);
    glAttachShader(program, fs);
    glAttachShader(program, vs);
    glLinkProgram(program);
    glValidateProgram(program);
    glDeleteShader(fs);
    glDeleteShader(vs);
   
    return program;

}
string getShaderString(string path) {
    ifstream inFile;
    string tp;
    inFile.open(path);
    if (!inFile)
    {
      
        return "error";
    }
    string fContent = "";
    if (inFile.is_open())
    { // checking whether the file is open
        string t = string((std::istreambuf_iterator<char>(inFile)), std::istreambuf_iterator<char>());
        inFile.close();
        return t;
       
    }
    return "error";
   


}

int main(){
     string fragSahderPath = getPathF().u8string() + "\\fragShader.txt"; 
  
    string vertexShaderPath = getPathF().u8string() + "\\vertexShader.txt";
    string fragShader = getShaderString(fragSahderPath);
    string vertexShader = getShaderString(vertexShaderPath);
    unsigned int shader = CreateShader(vertexShader,fragShader);
    return 1;
}
