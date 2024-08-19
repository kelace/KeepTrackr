import React, { useEffect, useState, ChangeEvent } from "react";
import { useSelector } from 'react-redux';
import Card from "../Card/Card";
import "./Board.css";
import { MoreHorizontal } from "react-feather";
import Editable from "../Editable/Editable";
import Dropdown from "../Dropdown/Dropdown";
import { Droppable } from 'react-beautiful-dnd';
import { addCard } from '../tasksPageSlice';
import { useDispatch } from 'react-redux';
import { AppDispatch } from '../../../../app/store';
import { useParams } from 'react-router-dom';
import { SketchPicker } from 'react-color';


export default function Board(props: any) {
    const [show, setShow] = useState(false);
    const [dropdown, setDropdown] = useState(false);
    const [title, setTitle] = useState("");
    const dispatch = useDispatch<AppDispatch>();

    const cards = useSelector((x: any) => {
        let c = Array.from(x.tasks.cards.entities);
        c.sort((x: any, y: any) => x.order > y.order ? 1 : -1);

        return c.filter((el: any) => {

            if (el.boardId == props.id) return el;

        });
    });

    const { company } = useParams();

    //const handleTitleChange = (e : any) => {
    //    dispatch(changeNewBoardName(e.target.value));
    //}

    const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
        setTitle(e.target.value);
    };

    const addCardHandler = (value: string) => {
        dispatch(addCard({ order: cards.length + 1, title: value, boardId: props.id, companyName: company }));
    };

    useEffect(() => {
        document.addEventListener("keypress", (e) => {
            if (e.code === "Enter") setShow(false);
        });

        return () => {
            document.removeEventListener("keypress", (e) => {
                if (e.code === "Enter") setShow(false);
            });
        };
    });

    return (
        <div className="board">
          
            <div className="board__top">
                {show ? (
                    <div>
                        <input
                            className="title__input"
                            type={"text"}
                            value={title}
                            onChange={handleChange}
                        />
                    </div>
                ) : (
                    <div>
                        <p
                            onClick={() => {
                                setShow(true);
                            }}
                            className="board__title"
                        >
                            {props?.name || "Name of Board"}
                            <span className="total__cards">{cards?.length}</span>
                        </p>
                    </div>
                )}
                <div
                    onClick={() => {
                        setDropdown(true);
                    }}
                >
                    <MoreHorizontal />

                    {dropdown && (
                        <Dropdown
                            class="board__dropdown"
                            onClose={() => {
                                setDropdown(false);
                            }}
                        >
                            <p onClick={() => props.removeBoard(props.id)}>Delete Board</p>

                        </Dropdown>
                    )}
                </div>
            </div>

            <Droppable droppableId={props.id.toString()} type="card">
                {(provided) => (
                    <div
                        className="board__cards"
                        ref={provided.innerRef}
                        {...provided.droppableProps}
                    >
                        {cards.map((items: any, index: any) => (
                            <Card
                                bid={props.id}
                                id={items.id}
                                index={items.order}
                                key={items.id}
                                title={items.title}
                                tags={items.tags}
                                updateCard={props.updateCard}
                                removeCard={props.removeCard}
                                card={items}
                            />
                        ))}
                        {provided.placeholder}
                    </div>
                )}
            </Droppable>
            <div className="board__footer">
                <Editable
                    name={"Add Card"}
                    btnName={"Add Card"}
                    placeholder={"Enter Card Title"}

                    onSubmit={addCardHandler}
                />
            </div>
        </div>
    );
}
