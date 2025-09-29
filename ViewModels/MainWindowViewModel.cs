using System;
using System.Collections.Generic;
using System.Net.Mime;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_GuitarSongs.Models;

namespace Proyecto_GuitarSongs.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Guitar Song´s";

    [ObservableProperty]
    private Album album = new();
    
    [ObservableProperty]
    private string mensaje = string.Empty;
    
    [ObservableProperty]
    private bool modoCrear = true;
    
    [ObservableProperty]
    private bool modoEditar = false;
    
    [ObservableProperty]
    private List<Album> albunes = new();



    // Saber si el formato es seleccionado o no (por defecto CD/DVD)
    [RelayCommand]
    public void Mostrar_Opc_Avanzadas(object parameter)
    {
        CheckBox opciones = (CheckBox)parameter;
        if (opciones.IsChecked == false)
        {
            Album.formato = "CD/DVD";
        }
    }
    
    // Saber si las opciones avanzadas estan seleccionadas
    [ObservableProperty] 
    private bool avanzado = false;
    
    [RelayCommand]
    public void MostarOpcionAvanzado()
    {
        if (Avanzado == false)
        {
            Avanzado = true;
        }
        else
        {
            Avanzado = false;
        }
    }
    
    // Comprobar que la fecha sea desde hoy a futuro
    [RelayCommand]
    public void ComprobarFecha()
    {
        
    }
    
    private bool CheckDate()
    {
        if (Album.fechaSalida < DateTime.Today)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    // Metodo de crear y comprobar cada elemento
    [RelayCommand]
    public void CrearAlbum()
    {
        if (string.IsNullOrWhiteSpace(Album.titulo))
        {
            Mensaje = "Titulo incorrecto";
        }
        else if (string.IsNullOrWhiteSpace(Album.creador))
        {
            Mensaje = "Creador incorrecto";
        }
        else if (!CheckDate())
        {
            Mensaje = "Fecha incorrecta";
        }
        else if (int.IsNegative(Album.cantidad))
        {
            Mensaje = "Cantidad incorrecta";
        }
        else
        {
            Albunes.Add(Album);
            Mensaje = "Album Creado";
        }
    }










}